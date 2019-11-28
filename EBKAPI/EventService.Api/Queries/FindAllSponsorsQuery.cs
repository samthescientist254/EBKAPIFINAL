using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries.Dtos
{
   public class FindAllSponsorsQuery : IRequest<IEnumerable<SponsorQueryDto>>
    {
        public Guid EventId { get; set; }
    }
}
