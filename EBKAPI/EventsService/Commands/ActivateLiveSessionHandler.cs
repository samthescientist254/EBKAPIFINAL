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
    public class ActivateLiveSessionHandler : IRequestHandler<ActivateLiveSessionCommand, ActivateLiveSessionResult>
    {
        private readonly IAtendeeRepository atendeeRepository;
        public ActivateLiveSessionHandler(IAtendeeRepository atendeeRepository)
        {
            this.atendeeRepository = atendeeRepository;
        }
        public async Task<ActivateLiveSessionResult> Handle(ActivateLiveSessionCommand request, CancellationToken cancellationToken)
        {
            var session = await atendeeRepository.ActivateLiveSession(request.AttendanceCode);

            return new ActivateLiveSessionResult
            {
                Activated = session
            };
        }
    }
}
