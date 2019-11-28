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
    public class FindAllResourcesHandler : IRequestHandler<FindAllResourcesQuerry, IEnumerable<EventBagDto>>
    {
        private readonly IEventBag bag;
        public FindAllResourcesHandler(IEventBag bag)
        {
            this.bag = bag ?? throw new ArgumentNullException(nameof(bag));
        }

        public async Task<IEnumerable<EventBagDto>> Handle(FindAllResourcesQuerry request, CancellationToken cancellationToken)
        {
            var result = await bag.FindAll(request.EventId);
                return result.Select(p => new EventBagDto
                {
                    Description=p.Description,
                    EventName=p.Event.Name,
                    FileLink=p.FileLink,
                    FileName=p.FileName,
                    Id=p.Id
              
               }).ToList();
        }
       
    }
}
