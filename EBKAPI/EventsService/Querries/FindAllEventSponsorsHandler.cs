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
    public class FindAllEventSponsorsHandler : IRequestHandler<FindAllSponsorsQuery, IEnumerable<SponsorQueryDto>>
    {
        private readonly ISponsorRepository sponsor;
        public FindAllEventSponsorsHandler(ISponsorRepository sponsorRepository)
        {
            sponsor=sponsorRepository ?? throw new ArgumentNullException(nameof(sponsorRepository));
        }
        public async Task<IEnumerable<SponsorQueryDto>> Handle(FindAllSponsorsQuery request, CancellationToken cancellationToken)
        {
            var result = await sponsor.FindAllSponsorsInEvent(request.EventId);
            return result.Select(p => new SponsorQueryDto
            {
                CellContacts = p.CellContacts,
                EmailAddress = p.EmailAddress,
                EventCode = p.Event.Code,
                Image = p.Image,
                MoreInfo = p.MoreInfo,
                Name = p.Name,
                WebSiteLink = p.WebSiteLink,
                SponsorId = p.Id
            }).ToList();/*.Where(c => c.ev == request.EventId);*/
        }
    }
}
