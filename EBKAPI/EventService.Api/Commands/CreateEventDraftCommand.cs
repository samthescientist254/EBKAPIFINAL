using System;
using System.Collections.Generic;
using System.Text;
using EventService.Api.Commands.Dtos;
using MediatR;

namespace EventService.Api.Commands
{
   public class CreateEventDraftCommand:IRequest<CreateEventDraftResult>
    {
        public EventDraftDto eventDraft { get; set; }
    }
}
