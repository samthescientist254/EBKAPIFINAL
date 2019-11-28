using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Init
{
    public static class DataLoaderInstaller
    {
        public static IServiceCollection AddEventEventInitializer(this IServiceCollection services)
        {
            services.AddScoped<DataLoader>();
            return services;
        }
    }
}
