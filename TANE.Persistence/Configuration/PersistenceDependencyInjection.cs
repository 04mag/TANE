using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.RepositoryInterfaces;
using TANE.Persistence.Repositories;

namespace TANE.Persistence.Configuration
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection RegisterPersistenceLayer(this IServiceCollection services)
        {
            //Set base adress (Yarp adress) for http clients
            var baseAddress = new Uri("https://localhost:7100/"); // Adjust the base address as needed

            // Add your persistence-related services here

            //Add http clients
            services.AddHttpClient<IJwtTokenRepository, JwtTokenRepository>(client =>
            {
                client.BaseAddress = new Uri($"{baseAddress}"); // Adjust the base address when yarp is added (add "auth/")
            });

            //Repositories
            services.AddScoped<IJwtTokenRepository, JwtTokenRepository>();

            return services;
        }
    }
}
