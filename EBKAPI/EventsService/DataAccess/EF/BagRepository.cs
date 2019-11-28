using EventsService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.DataAccess.EF
{
    public class BagRepository : IEventBag
    {
        private readonly EbkEventDbContextFinal3_ eventDbContext;
        public BagRepository(EbkEventDbContextFinal3_ eventDbContext)
        {
            this.eventDbContext = eventDbContext ?? throw new ArgumentNullException(nameof(eventDbContext));

        }
        public async Task<List<EventBags>> FindAll(Guid eventid)
        {
            return await eventDbContext
                .Resources.Where(i=>i.Event.Id==eventid)
                .Include(s => s.Event)
                .ToListAsync();
        }

        public async Task<EventBags> FindById(Guid id)
        {
            return await eventDbContext.Resources.FirstOrDefaultAsync(r => r.Id == id);/*.Include(s => s.Event);*/
        }
    }
}
