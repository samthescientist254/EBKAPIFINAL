using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands
{
   public class ActivateEventCommand: IRequest<ActivateEventResult>
    {
        public Guid EventId { get; set; }
    }
}
