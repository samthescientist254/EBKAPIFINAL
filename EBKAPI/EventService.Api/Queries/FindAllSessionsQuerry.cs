using EventService.Api.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries
{
    public  class FindAllSessionsQuerry:IRequest<IEnumerable<EventSessionQueryDto>>
    {
        public Guid EventId { get; set; }
    }
}
