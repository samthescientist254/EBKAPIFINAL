using EventService.Api.Queries.Dtos;
using EventsService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EventsService.Domain.Atendee;

namespace EventsService.DataAccess.EF
{
    public class AtendeeRepository : IAtendeeRepository
    {
        private readonly EbkEventDbContextFinal3_ eventDbContext;
        public AtendeeRepository(EbkEventDbContextFinal3_ eventDbContext)
        {
            this.eventDbContext = eventDbContext ?? throw new ArgumentNullException(nameof(eventDbContext));

        }

        public async Task<bool> ActivateLiveSession(string atendanceCode)
        {
            return false;
            //var Events = await eventDbContext.Atendees.FirstOrDefaultAsync(o => o.AttendanceCode == atendanceCode);
            //bool saved = false;
            //Events.Status = AttendanceStatus.InSession;
            //var ok = await eventDbContext.SaveChangesAsync();
            //return saved = ok >= 1 ? true : false;
        }

        public Task<Atendee> CancelSubscription(string atendanceCode)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Atendee>> FindAllActive()
        {
            return await eventDbContext
                 .Atendees
                 .Include(s => s.Event)
                 .Where(e => e.Status == AttendanceStatus.InSession)
                 .ToListAsync();
        }

        public async Task<List<Atendee>> FindAllSubscribed(Guid EventId)
        {
            return await eventDbContext
                .Atendees
                .Where(e => e.Status == AttendanceStatus.Subscribed && e.Event.Id == EventId).Include(s => s.Members).Where(r=>r.Members.Registered==true)/*.ThenInclude(c=>c.Country)*/
                .ToListAsync();
        }

        public async Task<List<Atendee>> FindAllSubscriptionCancelled()
        {
            //var querry = (from A in eventDbContext.Atendees
            //              join B in eventDbContext.Membership on A.EbKRegNumber equals B.EbkRegNumber).ToListAsync();
            return await eventDbContext
                .Atendees
                .Include(s => s.Event)
                .Where(e => e.Status == AttendanceStatus.Cancelled)
                .ToListAsync();
        }

        public async Task<Atendee> FindById(Guid id)
        {
            return await eventDbContext.Atendees.Include(s => s.Event).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Atendee> FindOneByAttendanceCode(string atendanceCode)
        {
            return null;
            //return await eventDbContext
            //     .Atendees
            //     .Include(s => s.Event)
            //     .FirstOrDefaultAsync(e => e.AttendanceCode.Equals(atendanceCode, StringComparison.InvariantCultureIgnoreCase));
        }
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
        public async Task<AtendeeLoginResponseDto> Login(AtendeeLoginDto credentials)
        {
           
            //steps
            //1.verify if user exists in membership;
            //2.querry his subscribed events
            //3.querry all upcoming events

            if (string.IsNullOrWhiteSpace(credentials.EbkRegNumber) || string.IsNullOrWhiteSpace(credentials.Password)) return null;
            var user = eventDbContext.Membership.SingleOrDefault(x => x.EbkRegNumber == credentials.EbkRegNumber);
            if (user == null) return null;

            if (user.EbkRegNumber != credentials.EbkRegNumber) return null;

            if (!VerifyPasswordHash(credentials.Password, user.PasswordHash, user.PasswordSalt))
                return null;
            //querry all events
            //var events = eventDbContext.Events.ToList();
            //IQueryable<EventDto> all=eventDbContext.Events.Select<EventDt
            var My_SubscribedEvents = (from A in eventDbContext.Atendees.Where(r => r.EbKRegNumber == credentials.EbkRegNumber)
                          join B in eventDbContext.Events.Where(s=>s.Status==EventStatus.Active) on A.Event.Id equals B.Id into U
                          from Y in U
                          select new EventDto
                          {
                              Code=Y.Code,
                              Description=Y.Description,
                              EndDate=Y.EndDate,
                              EventId=Y.Id,
                              Location=Y.Location,
                              Name=Y.Name,
                              StartDate=Y.StartDate,
                              Title=Y.Title,
                              Image=Y.Image
                          });
            var My_Pastevents = (from A in eventDbContext.Atendees.Where(r => r.EbKRegNumber == credentials.EbkRegNumber)
                                     join B in eventDbContext.Events.Where(s => s.Status == EventStatus.Executed) on A.Event.Id equals B.Id into U
                                     from Y in U
                                     select new EventDto
                                     {
                                         Code = Y.Code,
                                         Description = Y.Description,
                                         EndDate = Y.EndDate,
                                         EventId = Y.Id,
                                         Location = Y.Location,
                                         Name = Y.Name,
                                         StartDate = Y.StartDate,
                                         Title = Y.Title,
                                         Image = Y.Image
                                     });
            var AllUpcomingEvents = (
                                 from Y in eventDbContext.Events.Where(s => s.Status == EventStatus.Draft) 
                                 
                                 select new EventDto
                                 {
                                     Code = Y.Code,
                                     Description = Y.Description,
                                     EndDate = Y.EndDate,
                                     EventId = Y.Id,
                                     Location = Y.Location,
                                     Name = Y.Name,
                                     StartDate = Y.StartDate,
                                     Title = Y.Title,
                                     Image = Y.Image
                                 });
            var MyProfile = (
                               from Y in eventDbContext.Membership.Where(s => s.EbkRegNumber == credentials.EbkRegNumber)

                               select new AtendeeDto
                               {
                                 Email=Y.Email,
                                 FirstName=Y.FirstName,
                                 EbKRegNumber=Y.EbkRegNumber,
                                 Image=Y.Image,
                                 LastName=Y.LastName,
                                 Organisation=Y.OrganisationName,
                                 OriginCountry=Y.Country.Name,
                                 Telephone=Y.Phone,
                                 PosterID=Y.Id
                               });
            //var MyEvents = eventDbContext.Atendees.Where(e => e.EbKRegNumber == credentials.EbkRegNumber).Include(e => e.Event);

            //var MyProfile = eventDbContext.Membership.FirstOrDefaultAsync(e => e.EbkRegNumber == credentials.EbkRegNumber);

            return new AtendeeLoginResponseDto
            {
                MyProfile = MyProfile,
                MySubscribedEvents= My_SubscribedEvents,
                MySubscribedPastEvents=My_Pastevents,
                UpcomingEvents= AllUpcomingEvents
            };
        }

        public async Task<Atendee> Subscibe(Atendee atendee)
        {
            eventDbContext.Atendees.Add(atendee);
            await eventDbContext.SaveChangesAsync();
            return atendee;
        }
    }
}
