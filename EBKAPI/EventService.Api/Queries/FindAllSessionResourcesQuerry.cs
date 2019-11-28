using EventService.Api.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries
{
    public class FindAllSessionResourcesQuerry:IRequest<IEnumerable<ResourceQuerryDto>>
    {
        public Guid SessionId { get; set; }
    }
}
