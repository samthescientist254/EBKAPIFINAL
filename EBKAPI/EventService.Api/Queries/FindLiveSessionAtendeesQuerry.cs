using EventService.Api.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries
{
   public class FindLiveSessionAtendeesQuerry : IRequest<IEnumerable<AtendeeDto>>
    {
        public Guid SessionId { get; set; }
    }

}
