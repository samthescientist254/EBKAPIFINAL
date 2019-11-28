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
    public class FindAllUpcomingSessionsHandler : IRequestHandler<FindAllSessionsQuerry, IEnumerable<EventSessionQueryDto>>
    {
        private readonly ISessionRepository sessionRepository;
        public FindAllUpcomingSessionsHandler(ISessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository ?? throw new ArgumentNullException(nameof(sessionRepository));
        }
        public async Task<IEnumerable<EventSessionQueryDto>> Handle(FindAllSessionsQuerry request, CancellationToken cancellationToken)
        {
            var result = await sessionRepository.FindAllUpcoming(request.EventId);
            return result.Select(p => new EventSessionQueryDto
            {
                Day = p.Day,
                EndTime = p.EndTime,
                StartTime = p.StartTime,
                Id = p.Id,
                Name = p.Name,
                Venue = p.Venue
            }).OrderByDescending(x=>x.Day).Distinct().ToList();
        }
    }
}
