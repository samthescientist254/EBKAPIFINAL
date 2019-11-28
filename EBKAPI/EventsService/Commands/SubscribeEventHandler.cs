using EventService.Api.Commands;
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
    public class SubscribeEventHandler:IRequestHandler<SubscribeToEventCommand, SubscribeToEventResult>
    {
        private readonly IAtendeeRepository Subscriber;
        public SubscribeEventHandler(IAtendeeRepository atendeeRepository)
        {
            Subscriber = atendeeRepository;
        }

        public async Task<SubscribeToEventResult> Handle(SubscribeToEventCommand request, CancellationToken cancellationToken)
        {
            var subscriber = Atendee.SubscribeToEvent(
                
                request.Subsciber.EventCode,
                request.Subsciber.EbKRegNumber
                );
            await Subscriber.Subscibe(subscriber);
            return new SubscribeToEventResult
            {
                Status = subscriber.Status.ToString()
            };
        }
    }
}

