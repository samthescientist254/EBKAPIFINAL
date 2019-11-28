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
    public class CancelSubscriptionHandler : IRequestHandler<CancelSubscriptionCommand, CancelSubscriptionResult>
    {
        private readonly IAtendeeRepository Subscriber;
        public CancelSubscriptionHandler(IAtendeeRepository atendeeRepository)
        {
            Subscriber = atendeeRepository;
        }
        public async Task<CancelSubscriptionResult> Handle(CancelSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscriber = await Subscriber.FindOneByAttendanceCode(request.AttendanceCode);
            subscriber.CancelSubscription();
            return new CancelSubscriptionResult
            {
                EbkRegNo = subscriber.EbKRegNumber
            };
        }
    }
}
