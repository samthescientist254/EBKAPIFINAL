using EventsService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.DataAccess.EF
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly EbkEventDbContextFinal3_ eventDbContext;
        public SponsorRepository(EbkEventDbContextFinal3_ eventDbContext)
        {
            this.eventDbContext = eventDbContext ?? throw new ArgumentNullException(nameof(eventDbContext));

        }
        public Task<Sponsors> Add(Sponsors sporsors)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Sponsors>> FindAllSponsorsInEvent(Guid eventId)
        {
            return await eventDbContext
                .Sponsors
                .Where(e => e.Event.Id == eventId).Include(e=>e.Event)
                .ToListAsync();
        }
        public async Task<Sponsors> FindOne(Guid id)
        {
            return await eventDbContext.Sponsors.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
