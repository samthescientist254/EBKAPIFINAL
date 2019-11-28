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
    public class LoginAtendeeQueryHandler : IRequestHandler<LoginResponseDataQuery, AtendeeLoginResponseDto>
    {
        private readonly IMemberRepository member;
        private readonly IAtendeeRepository atendee;
        public LoginAtendeeQueryHandler(IAtendeeRepository atendee)
        {
            this.atendee = atendee ?? throw new ArgumentNullException(nameof(atendee));
        }
        public async Task<AtendeeLoginResponseDto> Handle(LoginResponseDataQuery request, CancellationToken cancellationToken)
        {
            var RESPONSE =await atendee.Login(request.LoginCredentials);
            return RESPONSE;
        }
    }
}
