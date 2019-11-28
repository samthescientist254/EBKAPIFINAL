using EventService.Api.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries
{
    public class FindAtendeeByIdQuery: IRequest<AtendeeDto>
    {
        public Guid AtendeerId { get; set; }
    }
}
   

