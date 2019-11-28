using EventsService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.DataAccess.EF
{
    public class SessionRepository: ISessionRepository
    {
        private readonly EbkEventDbContextFinal3_ eventDbContext;
        public SessionRepository(EbkEventDbContextFinal3_ eventDbContext)
        {
            this.eventDbContext = eventDbContext ?? throw new ArgumentNullException(nameof(eventDbContext));
        }

        public Task<List<EventSessions>> ActivateLive(Guid sessioId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EventSessions>> FindAllActive(string EventCode)
        {
            return await eventDbContext
               .EventSessions
               .Where(e => e.Status == SessionStatus.Live && e.EventCode==EventCode)
               .ToListAsync();
        }

        public async Task<List<EventSessions>> FindAllClosed(string EventCode)
        {
            return await eventDbContext
              .EventSessions
              .Where(e => e.Status == SessionStatus.Ended && e.EventCode == EventCode)
              .ToListAsync();
        }

        public async Task<List<EventSessions>> FindAllUpcoming(Guid EventId)
        {
            return await eventDbContext
               .EventSessions
               .Where(e => e.Status == SessionStatus.Created && e.Event.Id == EventId).OrderByDescending(o => o.Id)

               .ToListAsync();
        }

        public async Task<EventSessions> FindById(Guid id)
        {
            return await eventDbContext.EventSessions.Include(s => s.Event).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
