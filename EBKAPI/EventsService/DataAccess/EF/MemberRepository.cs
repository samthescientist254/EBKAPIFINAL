using EventService.Api.Commands.Dtos;
using EventsService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.DataAccess.EF
{
    public class MemberRepository : IMemberRepository
    {
        private readonly EbkEventDbContextFinal3_ eventDbContext;
        public MemberRepository(EbkEventDbContextFinal3_ eventDbContext)
        {
            this.eventDbContext = eventDbContext ?? throw new ArgumentNullException(nameof(eventDbContext));

        }
        public Task<List<Members>> FindAllActive()
        {
            throw new NotImplementedException();
        }

        public Task<List<Members>> FindAllSubscribed()
        {
            throw new NotImplementedException();
        }

        public async Task<Members> FindById(Guid id)
        {
            using (eventDbContext)
            {
                return await eventDbContext.Membership.FirstOrDefaultAsync(e => e.Id == id);
            }
         
        }

        public async Task<Members> FindByRegistrationNumber(string RegNumber)
        {
            using (eventDbContext)
            {
                return await eventDbContext.Membership.FirstOrDefaultAsync(e => e.EbkRegNumber == RegNumber);//.FirstOrDefaultAsync();
            }
           
        }


        public async Task<bool> Update(MemberDto atendee)
        {
            using (eventDbContext)
            {
                bool Updated = true;
                var member = eventDbContext.Membership.FirstOrDefault(m => m.EbkRegNumber == atendee.EbkRegNumber);
                if (member == null) throw new AppException("Member not found");
                //var DefaultCountryId = eventDbContext.Countries.FirstOrDefault().Id;
                if (!string.IsNullOrWhiteSpace(atendee.UserName) && atendee.UserName != member.UserName)
                {
                    //throw error if username is already taken
                    if (eventDbContext.Membership.Any(m => m.UserName == atendee.UserName))

                        throw new AppException("Username" + atendee.UserName + "is already taken");
                    member.UserName = atendee.UserName;
                }
                if (!string.IsNullOrWhiteSpace(atendee.FirstName))
                    member.FirstName = atendee.FirstName;
                if (!string.IsNullOrWhiteSpace(atendee.LastName))
                    member.LastName = atendee.LastName;
                if (!string.IsNullOrWhiteSpace(atendee.Email))
                    member.Email = atendee.Email;
                if (!string.IsNullOrWhiteSpace(atendee.Phone))
                    member.Phone = atendee.Phone;
                if ((atendee.Image) != null)
                    member.Image = atendee.Image;
                if (!string.IsNullOrWhiteSpace(atendee.OrganisationName))
                    member.OrganisationName = atendee.OrganisationName;

                if (!string.IsNullOrWhiteSpace(atendee.Password))
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash(atendee.Password, out passwordHash, out passwordSalt);
                    member.PasswordHash = passwordHash;
                    member.PasswordSalt = passwordSalt;

                }
                eventDbContext.Membership.Update(member);
                var saved = await eventDbContext.SaveChangesAsync();
                return Updated = saved > 0 ? true : false;
            }
                     
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> Onboard(MemberDto member)
        {
            //EbkEventDbContextFinal eventDbContext = new EbkEventDbContextFinal();
            //var context = new EbkEventDbContextFinal();
            bool Updated = true;
            using (eventDbContext) {
               
                var _member = eventDbContext.Membership.FirstOrDefault(m => m.EbkRegNumber == member.EbkRegNumber);
               // var DefaultCountryId = eventDbContext.Countries.FirstOrDefault().Id;
                if (member == null) throw new AppException("Member not found");
               /* if (!string.IsNullOrWhiteSpace(member.UserName) && _member.UserName != member.UserName)
                {
                    //throw error if username is already taken
                    if (eventDbContext.Membership.Any(m => m.UserName == member.UserName))

                        throw new AppException("Username" + member.UserName + "is already taken");
                    _member.UserName = member.UserName;
                }*/
               
               // _member.Country.Id = DefaultCountryId;
                if (!string.IsNullOrWhiteSpace(member.FirstName))
                    _member.FirstName = member.FirstName;
             if (!string.IsNullOrWhiteSpace(member.LastName))
                    _member.LastName = member.LastName;
                if (!string.IsNullOrWhiteSpace(member.Email))
                    _member.Email = member.Email;
                if (!string.IsNullOrWhiteSpace(member.Phone))
                    _member.Phone = member.Phone;
                 if (!string.IsNullOrWhiteSpace(member.Image))
                _member.Image = member.Image;
                if (!string.IsNullOrWhiteSpace(member.OrganisationName))
                    _member.OrganisationName = member.OrganisationName;
                _member.Status =0;
                _member.EbkStatus = 0;
                _member.Registered = true;
                _member.Gender = (Gender)member.Gender;
               
                if (!string.IsNullOrWhiteSpace(member.Password))
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash(member.Password, out passwordHash, out passwordSalt);
                    _member.PasswordHash = passwordHash;
                    _member.PasswordSalt = passwordSalt;

                }
                eventDbContext.Membership.Update(_member);
                var saved = await eventDbContext.SaveChangesAsync();
                return Updated = saved > 0 ? true : false;
            }
        }
    }
}
