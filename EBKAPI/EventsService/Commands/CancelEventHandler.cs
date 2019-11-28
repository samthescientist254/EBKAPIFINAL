using EventService.Api.Commands.Dtos;
using EventsService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventsService.Commands
{
    public class CancelEventHandler : IRequestHandler<CancelEventCommand, CancelEventResult>
    {
        private readonly IEventRepository @event;
        public CancelEventHandler(IEventRepository @event)
        {
            this.@event = @event;
        }
        public async Task<CancelEventResult> Handle(CancelEventCommand request, CancellationToken cancellationToken)
        {
            var Event = await @event.FindById(request.EventId);
            Event.CancelEvent();
            return new CancelEventResult
            {
                EventId = Event.Id
            };
        }
    }
}
