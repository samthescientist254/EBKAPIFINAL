using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public interface IEventRepository
    {
        Task<Event> Add(Event @event);
        Task<List<Event>> FindAllActive();
        Task<Event> FindOne(Guid id);
        Task<Event> FindById(Guid id);
        Task<bool> ActivateEvent(Guid id);
    }
}
