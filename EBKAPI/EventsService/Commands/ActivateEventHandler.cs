using EventService.Api.Commands;
using EventsService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventsService.Commands
{
    public class ActivateEventHandler : IRequestHandler<ActivateEventCommand, ActivateEventResult>
    {
        private readonly IEventRepository @event;
        public ActivateEventHandler(IEventRepository @event)
        {
            this.@event = @event;
        }
        public async Task<ActivateEventResult> Handle(ActivateEventCommand request, CancellationToken cancellationToken)
        {
            
            var Events = await @event.ActivateEvent(request.EventId);


            return new ActivateEventResult
            {
                Activated = Events
            };
        }
    }
}
