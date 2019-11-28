using EventService.Api.Queries.Dtos;
using EventsService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventsService.Querries
{
    public class FindMemberByRegNumberHandler : IRequestHandler<FindMemberByRegNumberQuery, MembersQueryDto>
    {
        private readonly IMemberRepository member;
        public FindMemberByRegNumberHandler(IMemberRepository member)
        {
            this.member = member ?? throw new ArgumentNullException(nameof(member));
        }
        public async Task<MembersQueryDto> Handle(FindMemberByRegNumberQuery request, CancellationToken cancellationToken)
        {
            var result = await member.FindByRegistrationNumber(request.EbkRegNumber);
            return result != null ? new MembersQueryDto
            {
               Phone=result.Phone,
               EbkRegNumber=result.EbkRegNumber,
               Email=result.Email,
               FirstName=result.FirstName,
               Id=result.Id,
               Image=result.Image,
               LastName=result.LastName,
               OrganisationName=result.OrganisationName,
               UserName=result.UserName,
               //Country=result.Country.Name,
              // Gender=result.Gender.ToString(),
               Status=result.Status.ToString()
            } : null;
        }
    }
}
