using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public interface IEventBag
    {
        Task<List<EventBags>> FindAll(Guid eventid);
        Task<EventBags> FindById(Guid id);
    }
}
