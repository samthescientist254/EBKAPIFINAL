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
    public class FindAllSubscribedAtendeesHandler : IRequestHandler<FindAllAtendeesQuery, IEnumerable<AtendeeDto>>
    {
        private readonly IAtendeeRepository atendeeRepository;
        public FindAllSubscribedAtendeesHandler(IAtendeeRepository atendeeRepository)
        {
            this.atendeeRepository = atendeeRepository ?? throw new ArgumentNullException(nameof(atendeeRepository));
        }
        public async Task<IEnumerable<AtendeeDto>> Handle(FindAllAtendeesQuery request, CancellationToken cancellationToken)
        {
            var result = await atendeeRepository.FindAllSubscribed(request.EventId);
            return result.Select(p => new AtendeeDto
            {
                RegistrationDate = p.RegistrationDate,
                FirstName=p.Members.FirstName,
                LastName=p.Members.LastName,
                Email=p.Members.Email,
                Image=p.Members.Image,
                Organisation=p.Members.OrganisationName,
                Telephone=p.Members.Phone,
               // OriginCountry=p.Members.Country.Name,
                EbKRegNumber=p.EbKRegNumber,
                PosterID=p.Id
               // MessageToken=p.Members.Message.Message,
               // MessageId=p.Members.Message.Id
            });
        }
    }
}
