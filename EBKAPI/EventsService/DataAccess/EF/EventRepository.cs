using EventsService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.DataAccess.EF
{
    public class EventRepository: IEventRepository
    {
        private readonly EbkEventDbContextFinal3_ eventDbContext;
        public EventRepository(EbkEventDbContextFinal3_ eventDbContext)
        {
            this.eventDbContext = eventDbContext ?? throw new ArgumentNullException(nameof(eventDbContext));

        }

        public async Task<bool> ActivateEvent(Guid id)
        {
            var Events = await eventDbContext.Events.FirstOrDefaultAsync(o => o.Id == id);
            bool saved = false;
            Events.Status = EventStatus.Active;
           var ok= await eventDbContext.SaveChangesAsync();
           return saved = ok >= 1 ? true : false;
        }

        public async Task<Event> Add(Event @event)
        {
             eventDbContext.Events.Add(@event);
            await eventDbContext.SaveChangesAsync();
           // Guid a = @event.Id;
            return @event;
        }

        public async Task<List<Event>> FindAllActive()
        {
            return await eventDbContext
                .Events
                .Include(s => s.Sporsors)
                .Include(sp => sp.Speakers)
                .Where(e => e.Status == EventStatus.Active)
                .ToListAsync();
        }

        public async Task<Event> FindById(Guid id)
        {
            return await eventDbContext.Events.Include(s => s.Speakers).Include(sp => sp.Sporsors).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Event> FindOne(Guid id)
        {
            return await eventDbContext
                .Events
                .Include(s => s.Sporsors)
                .Include(sp => sp.Speakers)
                .FirstOrDefaultAsync(e => e.Id==id);
        }
    }
}
