using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries.Dtos
{
   public class LoginResponseDataQuery : IRequest<AtendeeLoginResponseDto>
    {
        public AtendeeLoginDto LoginCredentials { get; set; }
    }
}
