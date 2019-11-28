using EventService.Api.Queries;
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
    public class FindMessagesByRegnumberQueryHandler : IRequestHandler<FindMessagesByRegNumberQuery, MessageQueryDto>
    {
        private readonly IMessageRepository message;
        public FindMessagesByRegnumberQueryHandler(IMessageRepository message)
        {
            this.message = message ?? throw new ArgumentNullException(nameof(message));
        }
        public async Task<MessageQueryDto> Handle(FindMessagesByRegNumberQuery request, CancellationToken cancellationToken)
        {
            var result = await message.Get(request.EbkRegNumber);
            return result != null ? new MessageQueryDto
            {
               MessageToken=result.Message,
               TokenId=result.Id
            } : null;
        }
    }
}
