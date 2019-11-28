using EventService.Api.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries
{
    public class FindMessagesByRegNumberQuery : IRequest<MessageQueryDto>
    {
        public string EbkRegNumber { get; set; }
    }

}
