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
            services.AddHttpClient<IDagRepository, DagRepository>(client =>
            {
                client.BaseAddress = new Uri($"{baseAddress}"); // Adjust the base address when yarp is added (add "dag/")
            });

            services.AddHttpClient<IDagSkabelonRepository, DagSkabelonRepository>(client =>
            {
                client.BaseAddress = new Uri($"{baseAddress}"); // Adjust the base address when yarp is added (add "dagskabelon/")
            });

            services.AddHttpClient<IJwtTokenRepository, JwtTokenRepository>(client =>
            {
                client.BaseAddress = new Uri($"{baseAddress}"); // Adjust the base address when yarp is added (add "auth/")
            });

            services.AddHttpClient<IKundeRepository, KundeRepository>(client =>
            {
                client.BaseAddress = new Uri($"{baseAddress}"); // Adjust the base address when yarp is added (add "kunde/")
            });

            services.AddHttpClient<IRejsePlanRepository, RejsePlanRepository>(client =>
            {
                client.BaseAddress = new Uri($"{baseAddress}"); // Adjust the base address when yarp is added (add "rejseplan/")
            });

            services.AddHttpClient<IRejsePlanSkabelonRepository, RejsePlanSkabelonRepository>(client =>
            {
                client.BaseAddress = new Uri($"{baseAddress}"); // Adjust the base address when yarp is added (add "rejseplanskabelon/")
            });

            services.AddHttpClient<ITurRepository, TurRepository>(client =>
            {
                client.BaseAddress = new Uri($"{baseAddress}"); // Adjust the base address when yarp is added (add "tur/")
            });

            services.AddHttpClient<ITurSkabelonRepository, TurSkabelonRepository>(client =>
            {
                client.BaseAddress = new Uri($"{baseAddress}"); // Adjust the base address when yarp is added (add "turskabelon/")
            });

            //Repositories
            services.AddScoped<IDagRepository, DagRepository>();
            services.AddScoped<IDagSkabelonRepository, DagSkabelonRepository>();
            services.AddScoped<IJwtTokenRepository, JwtTokenRepository>();
            services.AddScoped<IKundeRepository, KundeRepository>();
            services.AddScoped<IRejsePlanRepository, RejsePlanRepository>();
            services.AddScoped<IRejsePlanSkabelonRepository, RejsePlanSkabelonRepository>();
            services.AddScoped<ITurRepository, TurRepository>();
            services.AddScoped<ITurSkabelonRepository, TurSkabelonRepository>();

            return services;
        }
    }
}
