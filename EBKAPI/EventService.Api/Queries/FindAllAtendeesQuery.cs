using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries.Dtos
{
    public class FindAllAtendeesQuery: IRequest<IEnumerable<AtendeeDto>>
    {
        public Guid EventId { get; set; }
    }
}
