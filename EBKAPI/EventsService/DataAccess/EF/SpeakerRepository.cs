using EventService.Api.Commands.Dtos;
using EventsService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.DataAccess.EF
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly EbkEventDbContextFinal3_ eventDbContext;
        public SpeakerRepository(EbkEventDbContextFinal3_ eventDbContext)
        {
            this.eventDbContext = eventDbContext ?? throw new ArgumentNullException(nameof(eventDbContext));

        }
        public Task<Speakers> Add(Speakers speakers)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Speakers>> FindAllSpeakersInEvent(Guid eventId)
        {
            return await eventDbContext
                .Speakers
                .Where(e => e.Event.Id == eventId)
                .ToListAsync();
        }

        public async Task<List<EventSessions>> FindMySessions(Guid speakerId)
        {
            return await eventDbContext
               .EventSessions
               .Where(e => e.SpeakerId == speakerId).OrderByDescending(o => o.Id)
               .ToListAsync();
        }

        public async Task<Speakers> FindOne(Guid id)
        {
            return await eventDbContext.Speakers.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> Update(SpeakerDto speaker)
        {
            bool Updated = true;
            var eventspeaker = eventDbContext.Speakers.FirstOrDefault(m => m.Email == speaker.Email);
            if (eventspeaker == null) throw new AppException("Speaker not found");
            if (!string.IsNullOrWhiteSpace(speaker.Email) && speaker.Email != eventspeaker.Email)
            {
                if (eventDbContext.Speakers.Any(m => m.Email == speaker.Email))
                    throw new AppException("Email: " + speaker.Email + "is already taken");
                eventspeaker.Email = speaker.Email;
            }
            if (!string.IsNullOrWhiteSpace(speaker.FirstName))
                eventspeaker.FirstName = speaker.FirstName;
            if (!string.IsNullOrWhiteSpace(speaker.LastName))
                eventspeaker.LastName = speaker.LastName;
            if (!string.IsNullOrWhiteSpace(speaker.Email))
                eventspeaker.Email = speaker.Email;
            if (!string.IsNullOrWhiteSpace(speaker.PhoneNumber)) 
                eventspeaker.PhoneNumber = speaker.PhoneNumber;
            if ((speaker.Image)!=null)
                eventspeaker.Image = speaker.Image;
            if (!string.IsNullOrWhiteSpace(speaker.OriginCompany))
                eventspeaker.OriginCompany = speaker.OriginCompany;
            if (!string.IsNullOrWhiteSpace(speaker.MoreInfo))
                eventspeaker.MoreInfo = speaker.MoreInfo;
            if (!string.IsNullOrWhiteSpace(speaker.Title))
                eventspeaker.Title = speaker.Title;
            eventDbContext.Speakers.Update(eventspeaker);
            var saved = await eventDbContext.SaveChangesAsync();
            return Updated = saved > 0 ? true : false;
        }
    }
}
