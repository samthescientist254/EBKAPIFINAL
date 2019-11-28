using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands.Dtos
{
    public class CancelEventCommand:IRequest<CancelEventResult>
    {
        public Guid EventId { get; set; }
    }
}
