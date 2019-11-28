using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public interface IResourceRepository
    {
        Task<EventBags> Add(EventBags eventBags);
        Task<bool> Delete(EventBags eventBags);
        Task<List<EventBags>> FindAllSessionResources(string sessionid);
        Task<EventBags> FindById(Guid id);
    }
}
