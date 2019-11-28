using EventService.Api.Commands.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
   public interface ISpeakerRepository
    {
        Task<Speakers> Add(Speakers speakers);
        Task<List<Speakers>> FindAllSpeakersInEvent(Guid eventId);
        Task<Speakers> FindOne(Guid id);
        Task<bool> Update(SpeakerDto speaker);
        Task<List<EventSessions>> FindMySessions(Guid speakerId);
    }
}
