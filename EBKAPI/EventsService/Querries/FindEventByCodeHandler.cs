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
    public class FindEventByCodeHandler : IRequestHandler<FindEventByCodeQuerry, EventDto>
    {
        private readonly IEventRepository eventRepository;
        public FindEventByCodeHandler(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }
        public async Task<EventDto> Handle(FindEventByCodeQuerry request, CancellationToken cancellationToken)
        {
            var result = await eventRepository.FindOne(request.EventId);
            return result != null ? new EventDto
            {
                Code=result.Code,
                Description=result.Description,
                EndDate=result.EndDate,
                StartDate=result.StartDate,
                Location=result.Location,
                Title=result.Title,
                Status=result.Status.ToString(),
                Image=result.Image,
                Name=result.Name
            } : null;
        }
    }
}
