using EventsService.DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Init
{
    public class DataLoader
    {
        private readonly EbkEventDbContextFinal3_ dbContext;
        public DataLoader(EbkEventDbContextFinal3_ dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Seed()
        {
            dbContext.Database.EnsureCreated();
            if (dbContext.Events.Any())
            {
                return;
            }
            dbContext.Events.Add(DemoEventFactory.EventOne());
            dbContext.SaveChanges();
        }
    }
}
