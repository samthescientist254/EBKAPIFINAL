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
    public class UpdateMessageHandler : IRequestHandler<UpdateMessageCommand, UpdateMessageResult>
    {
        private readonly IMessageRepository message;
        public UpdateMessageHandler(IMessageRepository messageRepository)
        {
            this.message = messageRepository;
        }

        public async  Task<UpdateMessageResult> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var status = await message.Update(request.UpdatedMessage);
            return new UpdateMessageResult
            {
                Updated = status
            };
        }
    }
}
