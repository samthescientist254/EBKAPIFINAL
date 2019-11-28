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
    public class AddMessageHandler : IRequestHandler<SendMessageCommand, SendMessageResult>
    {
        private readonly IMessageRepository message;
        public AddMessageHandler(IMessageRepository message )
        {
            this.message = message;
        }
        public async Task<SendMessageResult> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var draft = Messages.SendMessage(
               request.message.DeleteForMe,
               request.message.DeleteForYou,
               request.message.DeleteForAll,
               request.message.Message,
               request.message.SenderId
                );
            await message.NewMessage(draft);
            return new SendMessageResult
            {
                Id = draft.Id
            };
        }
    }
}
