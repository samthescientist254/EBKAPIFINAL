using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries.Dtos
{
   public class FindMemberByRegNumberQuery : IRequest<MembersQueryDto>
    {
        public string EbkRegNumber { get; set; }
    }

}
