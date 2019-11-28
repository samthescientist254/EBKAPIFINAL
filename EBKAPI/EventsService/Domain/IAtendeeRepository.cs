using EventService.Api.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
   public interface IAtendeeRepository
    {
        Task<Atendee> Subscibe(Atendee atendee);
        Task<Atendee> CancelSubscription(string atendanceCode);
        Task<List<Atendee>> FindAllActive();
        Task<List<Atendee>> FindAllSubscribed(Guid EventId);
        Task<List<Atendee>> FindAllSubscriptionCancelled();
        Task<Atendee> FindOneByAttendanceCode(string atendanceCode);
        Task<bool> ActivateLiveSession(string atendanceCode);
        Task<Atendee> FindById(Guid id);
        Task <AtendeeLoginResponseDto>Login(AtendeeLoginDto atendee);
    }
}
