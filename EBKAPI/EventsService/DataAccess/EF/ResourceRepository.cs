using EventsService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.DataAccess.EF
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly EbkEventDbContextFinal3_ eventDbContext;
        public ResourceRepository(EbkEventDbContextFinal3_ eventDbContext)
        {
            this.eventDbContext = eventDbContext ?? throw new ArgumentNullException(nameof(eventDbContext));
        }
        public async Task<EventBags> Add(EventBags eventBags)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(EventBags eventBags)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EventBags>> FindAllSessionResources(string sessionid)
        {
            return await eventDbContext
                .Resources
                .Where(e => e.Status != EventBags.ResourceStatus.deleted)
                .ToListAsync();
        }

        public async Task<EventBags> FindById(Guid id)
        {
            return await eventDbContext.Resources.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
