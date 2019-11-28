using EventsService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.DataAccess.EF
{
    public static class EFInstaller
    {
        public static IServiceCollection AddEFConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            var useInMemoryDatabase = configuration.GetSection("Settings").GetValue<bool>("UseInMemoryDatabase");
            services.AddDbContext<EbkEventDbContextFinal3_>(options=> {

                if (useInMemoryDatabase)
                {
                    options.UseInMemoryDatabase("PapaConnection");
                }else
                {
                    options.UseSqlServer(configuration.GetConnectionString("PapaConnection"));
                }

            });
            services.AddScoped<IEventRepository, EventRepository>();
            return services;
                }
    }
}
