using EventService.Api.Queries;
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
    public class FindIndividualSpeakerSessionsHandler : IRequestHandler<FindIndividualSpeakerSessionsQuery, IEnumerable<EventSessionQueryDto>>
    {
        private readonly ISpeakerRepository sessionRepository;
        public FindIndividualSpeakerSessionsHandler(ISpeakerRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository ?? throw new ArgumentNullException(nameof(sessionRepository));
        }
        public async Task<IEnumerable<EventSessionQueryDto>> Handle(FindIndividualSpeakerSessionsQuery request, CancellationToken cancellationToken)
        {
            var result = await sessionRepository.FindMySessions(request.SpeakerId);
            return result.Select(p => new EventSessionQueryDto
            {
                Day = p.Day,
                EndTime = p.EndTime,
                StartTime = p.StartTime,
                Id = p.Id,
                Name = p.Name,
                Venue = p.Venue,
                Status=p.Status.ToString()  
            }).ToList();
        }
    }
}
