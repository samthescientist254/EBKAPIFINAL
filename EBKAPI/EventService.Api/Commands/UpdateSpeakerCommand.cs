using EventService.Api.Commands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands
{
   public class UpdateSpeakerCommand : IRequest<UpdateSpeakerResult>
    {
        public SpeakerDto speaker { get; set; }
    }

}
