using EventService.Api.Queries.Dtos;
using EventsService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventsService.Querries
{
    public class FindAllEventSpeakersHandler : IRequestHandler<FindAllSpeakersQuery, IEnumerable<SpeakerQueryDto>>
    {
        private readonly ISpeakerRepository speaker;
        public FindAllEventSpeakersHandler(ISpeakerRepository speakerRepository)
        {
            speaker = speakerRepository ?? throw new ArgumentNullException(nameof(speakerRepository));
        }

        public async Task<IEnumerable<SpeakerQueryDto>> Handle(FindAllSpeakersQuery request, CancellationToken cancellationToken)
        {
            var result = await speaker.FindAllSpeakersInEvent(request.EventId);
            return result.Select(p => new SpeakerQueryDto
            {
                Email = p.Email,
                EventCode = p.EventCode,
                FirstName = p.FirstName,
                Image = p.Image,
                LastName = p.LastName,
                MoreInfo = p.MoreInfo,
                OriginCompany = p.OriginCompany,
                PhoneNumber = p.PhoneNumber,
                Title = p.Title,
                SpeakerId = p.Id
            }).ToList();
        }
        
    }
}
