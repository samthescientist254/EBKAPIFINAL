using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
   public interface ISponsorRepository
    {
        Task<Sponsors> Add(Sponsors sporsors);
        Task<List<Sponsors>> FindAllSponsorsInEvent(Guid eventId);
        Task<Sponsors> FindOne(Guid id);
    }
}
