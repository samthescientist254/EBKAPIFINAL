using EventService.Api.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries
{
    public class FindAtendeesByAtendanceCodeQuery: IRequest<EventDto>
    {
        public Guid AtendanceCode { get; set; }
    }
}
