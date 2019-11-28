using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public interface ISessionRepository
    {
        Task<List<EventSessions>> FindAllActive(string EventCode);
        Task<List<EventSessions>> FindAllClosed(string EventCode);
        Task<List<EventSessions>> FindAllUpcoming(Guid EventId);
        Task<List<EventSessions>> ActivateLive(Guid sessioId);
        Task<EventSessions> FindById(Guid id);
    }
}
