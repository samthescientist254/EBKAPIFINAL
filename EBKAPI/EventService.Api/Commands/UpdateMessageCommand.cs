using EventService.Api.Commands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands
{
    public class UpdateMessageCommand : IRequest<UpdateMessageResult>
    {
        public MessageDto UpdatedMessage { get; set; }
    }
}
