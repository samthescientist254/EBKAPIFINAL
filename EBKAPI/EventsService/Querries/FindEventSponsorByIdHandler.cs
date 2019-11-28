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
    public class FindEventSponsorByIdHandler : IRequestHandler<FindAllSponsorsByIdQuerry, SponsorQueryDto>
    {
        private readonly ISponsorRepository sponsor;
        public FindEventSponsorByIdHandler(ISponsorRepository sponsorRepository)
        {
            sponsor = sponsorRepository ?? throw new ArgumentNullException(nameof(sponsorRepository));
        }
        public async Task<SponsorQueryDto> Handle(FindAllSponsorsByIdQuerry request, CancellationToken cancellationToken)
        {
            var result = await sponsor.FindOne(request.SponsorId);
            return result != null ? new SponsorQueryDto
            {
                EventCode = result.EventCode,
                Image = result.Image,
                MoreInfo = result.MoreInfo,
                CellContacts=result.CellContacts,
                EmailAddress=result.EmailAddress,
                Name=result.Name,
                SponsorId=result.Id,
                WebSiteLink=result.WebSiteLink
            } : null;
        }
    }

}
