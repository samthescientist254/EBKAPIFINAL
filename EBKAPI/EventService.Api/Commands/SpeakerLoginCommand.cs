
using EventService.Api.Commands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using EventService;

namespace AuthService.Api.Commands
{
    public class SpeakerLoginCommand : IRequest<SpeakerLoginDto>
    {
        public AuthDto loginCredentials { get; set; }
    }

}
