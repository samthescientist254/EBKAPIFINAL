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
    public class FindEventSpeakerByIdHandler : IRequestHandler<FindAllSpeakersbyIdQuery, SpeakerQueryDto>
    {
        private readonly ISpeakerRepository speaker;
        public FindEventSpeakerByIdHandler(ISpeakerRepository speakerRepository)
        {
            speaker = speakerRepository ?? throw new ArgumentNullException(nameof(speakerRepository));
        }
        public async Task<SpeakerQueryDto> Handle(FindAllSpeakersbyIdQuery request, CancellationToken cancellationToken)
        {
            var result = await speaker.FindOne(request.SpeakerId);
            return result != null ? new SpeakerQueryDto
            {
                Email = result.Email,
                EventCode = result.EventCode,
                FirstName = result.FirstName,
                Image = result.Image.ToString(),
                LastName = result.LastName,
                MoreInfo = result.MoreInfo,
                OriginCompany = result.OriginCompany,
                PhoneNumber = result.PhoneNumber,
                Title = result.Title
            } : null;
        }
    }
   
}
