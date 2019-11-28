using EventService.Api.Queries;
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
    public class FindAllAtendeesInLiveSessionHandler:IRequestHandler<FindLiveSessionAtendeesQuerry,IEnumerable<AtendeeDto>>
    {
        private readonly IAtendeeRepository atendeeRepository;
        public FindAllAtendeesInLiveSessionHandler(IAtendeeRepository atendeeRepository)
        {
            this.atendeeRepository = atendeeRepository ?? throw new ArgumentNullException(nameof(atendeeRepository));
        }

        public async Task<IEnumerable<AtendeeDto>> Handle(FindLiveSessionAtendeesQuerry request, CancellationToken cancellationToken)
        {
            var result =await atendeeRepository.FindAllActive();
            return result.Select(p => new AtendeeDto
            {
               // AttendanceCode=p.AttendanceCode,
                EbKRegNumber=p.EbKRegNumber,
                EventCode=p.Event.Code,
                RegistrationDate=p.RegistrationDate
            }).ToList();
        }
    }
}
