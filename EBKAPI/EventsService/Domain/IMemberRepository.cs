using EventService.Api.Commands.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public interface IMemberRepository
    {
       // Task<Members> Onboard(Members atendee);
        Task<bool> Update(MemberDto atendee);
        Task<bool> Onboard(MemberDto member);
        Task<List<Members>> FindAllActive();
        Task<List<Members>> FindAllSubscribed();
        Task<Members> FindByRegistrationNumber(string RegNumber);
        Task<Members> FindById(Guid id);
    }
}
