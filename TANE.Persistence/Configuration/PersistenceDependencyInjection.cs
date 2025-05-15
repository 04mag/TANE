using Microsoft.Extensions.DependencyInjection;
using TANE.Application.Groups.Dage.Queries.Interfaces;
using TANE.Application.Groups.Dage.Queries;
using TANE.Application.Groups.Kunder.Queries;
using TANE.Application.Groups.Kunder.Queries.Interfaces;
using TANE.Application.Groups.Rejseplaner.Queries;
using TANE.Application.Groups.Rejseplaner.Queries.Interfaces;
using TANE.Application.Groups.Ture.Queries;
using TANE.Application.Groups.Ture.Queries.Interfaces;
using TANE.Application.Groups.TurSkabeloner.Queries.Interfaces;
using TANE.Application.Groups.TurSkabeloner.Queries;
using TANE.Application.RepositoryInterfaces;
using TANE.Persistence.Repositories;
using TANE.Application.Mappings;

namespace TANE.Persistence.Configuration
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection RegisterPersistenceLayer(this IServiceCollection services)
        {
            //Set base adress (Yarp adress) for http clients
            var baseAddress = new Uri("http://localhost:6001/"); // Adjust the base address as needed

            // Add your persistence-related services here

            //Add http clients
            services.AddHttpClient(
                "auth",
                client =>
                {
                    client.BaseAddress = new Uri(baseAddress, "auth/");
                });
            services.AddHttpClient(
                "rejseplan",
                client =>
                {
                    client.BaseAddress = new Uri(baseAddress, "rejseplan/");
                });
            services.AddHttpClient(
                "skabelon",
                client =>
                {
                    client.BaseAddress = new Uri(baseAddress, "skabelon/");
                });
            services.AddHttpClient(
                "kunde",
                client =>
                {
                    client.BaseAddress = new Uri(baseAddress, "kunde/");
                });

            //Repositories
            services.AddScoped<IDagRepository, DagRepository>();
            services.AddScoped<IDagSkabelonRepository, DagSkabelonRepository>();
            services.AddScoped<IJwtTokenRepository, JwtTokenRepository>();
            services.AddScoped<IKundeRepository, KundeRepository>();
            services.AddScoped<IRejseplanRepository, RejseplanRepository>();
            services.AddScoped<IRejseplanSkabelonRepository, RejseplanSkabelonRepository>();
            services.AddScoped<ITurRepository, TurRepository>();
            services.AddScoped<ITurSkabelonRepository, TurSkabelonRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReadTurSkabelon, ReadTurSkabelon>();
            services.AddScoped<IReadDag, ReadDag>();
            services.AddScoped<IReadTur, ReadTur>();
            services.AddScoped<IReadRejseplan, ReadRejseplan>();
            services.AddScoped<IReadKunde, ReadKunde>();

            services
                .AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }
    }
}
