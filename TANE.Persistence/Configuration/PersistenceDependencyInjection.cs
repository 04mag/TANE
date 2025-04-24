using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
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
            // Add your persistence-related services here

            //Repositories
            services.AddScoped<IJwtTokenRepository, JwtTokenRepository>();

            return services;
        }
    }
}
