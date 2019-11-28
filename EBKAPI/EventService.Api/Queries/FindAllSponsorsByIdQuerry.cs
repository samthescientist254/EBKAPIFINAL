using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries.Dtos
{
   public class FindAllSponsorsByIdQuerry : IRequest<SponsorQueryDto>
    {
        public Guid SponsorId { get; set; }
    }

}
