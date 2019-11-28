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
    public class FindAllEventsHandler : IRequestHandler<FindAllEventsQuerry, IEnumerable<EventDto>>
    {
        private readonly IEventRepository @event;
        public FindAllEventsHandler(IEventRepository eventRepository)
        {
            this.@event = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }
        public async Task<IEnumerable<EventDto>> Handle(FindAllEventsQuerry request, CancellationToken cancellationToken)
        {
            var result = await @event.FindAllActive();
            return result.Select(p => new EventDto {

                Code=p.Code,
                Description=p.Description,
                Image = p.Image,
                Name=p.Name,
                EventId=p.Id,
                Title=p.Title
            }).ToList();
        }
    }
}
