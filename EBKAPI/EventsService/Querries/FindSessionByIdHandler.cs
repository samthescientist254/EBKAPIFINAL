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
    public class FindSessionByIdHandler:IRequestHandler<FindSessionByIdQuery, EventSessionQueryDto>
    {
        private readonly ISessionRepository sessionRepository;
        public FindSessionByIdHandler(ISessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository ?? throw new ArgumentNullException(nameof(sessionRepository));
        }

        public async Task<EventSessionQueryDto> Handle(FindSessionByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await sessionRepository.FindById(request.SessionId);
            return result != null ? new EventSessionQueryDto
            {
               Day=result.Day,
               EndTime=result.EndTime,
               Name=result.Name,
               StartTime=result.StartTime,
               Venue=result.Venue
            } : null;
        }
    }
}
