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
    public class FindResourceByIdHandler : IRequestHandler<FindResourceById, EventBagDto>
    {
        private readonly IEventBag bag;
        public FindResourceByIdHandler(IEventBag bag)
        {
            this.bag = bag ?? throw new ArgumentNullException(nameof(bag));
        }

        public async Task<EventBagDto> Handle(FindResourceById request, CancellationToken cancellationToken)
        {
            var result = await bag.FindById(request.BagId);
            return result != null ? new EventBagDto
            {
                Description=result.Description,
                FileLink=result.FileLink,
                FileName=result.FileName,
                Id=result.Id
            } : null;
        }
    }
}
