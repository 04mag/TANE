using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using TANE.Application.Configuration;
using TANE.Application.Groups.Dage.Queries;
using TANE.Application.Groups.Dage.Queries.Interfaces;
using TANE.Application.Groups.JwtTokens.Commands.Interfaces;
using TANE.Application.Groups.TurSkabeloner.Queries.Interfaces;
using TANE.Application.Groups.TurSkabeloner.Queries;
using TANE.Application.RepositoryInterfaces;
using TANE.Persistence.Configuration;
using TANE.Persistence.Repositories;
using TANE.Presentation.BlazorWebAssemply.Authentication;
using TANE.Presentation.BlazorWebAssemply.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace TANE.Presentation.BlazorWebAssemply
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddScoped<IReadTurSkabelon, ReadTurSkabelon>();
            builder.Services.AddScoped<IReadDag, ReadDag>();


            builder.Services.AddScoped(sp => new HttpClient
                { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services
                .AddHttpClient<IDagRepository, DagRepository>(client =>
                {
                    client.BaseAddress = new Uri(
                        builder.Configuration["ApiSettings:RejseplanApiUrl"]
                    );
                });

            // Og tilsvarende for de andre repositorier
            builder.Services
                .AddHttpClient<ITurRepository, TurRepository>(client =>
                {
                    client.BaseAddress = new Uri(
                        builder.Configuration["ApiSettings:RejseplanApiUrl"]
                    );
                });

            builder.Services
                .AddHttpClient<IRejsePlanRepository, RejsePlanRepository>(client =>
                {
                    client.BaseAddress = new Uri(
                        builder.Configuration["ApiSettings:RejseplanApiUrl"]
                    );
                });

            builder.Services.AddAuthorizationCore();

            //Add layer services
            builder.Services.RegisterApplicationLayer();
            builder.Services.RegisterPersistenceLayer();

            builder.Services.AddRadzenComponents();

            builder.Services.AddScoped<BrowserStorageService>();

            builder.Services.AddScoped<CustomStateProvider>();

            builder.Services.AddScoped<AuthenticationStateProvider>(s =>
                s.GetRequiredService<CustomStateProvider>());


            var apiUrl = builder.Configuration["ApiSettings:RejseplanApiUrl"];
                builder.Services.AddHttpClient<IRejseplanClientService, RejseplanClientService>(client =>
                {
                    client.BaseAddress = new Uri(apiUrl);
                });
            
            await builder.Build().RunAsync();
        }
    }
}
