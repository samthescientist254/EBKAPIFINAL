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
    public class FindSubscribedAtendeeByIdHandler : IRequestHandler<FindAtendeeByIdQuery, AtendeeDto>
    {
        private readonly IAtendeeRepository atendeeRepository;
        public FindSubscribedAtendeeByIdHandler(IAtendeeRepository atendeeRepository)
        {
            this.atendeeRepository = atendeeRepository ?? throw new ArgumentNullException(nameof(atendeeRepository));
        }
        public async Task<AtendeeDto> Handle(FindAtendeeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await atendeeRepository.FindById(request.AtendeerId);
            return result != null ? new AtendeeDto
            {
                //EventCode = result.EventCode,
               // AttendanceCode=result.AttendanceCode,
                EbKRegNumber=result.EbKRegNumber,
               // RegistrationDate=result.RegistrationDate
            } : null;
           
        }
    }
}
