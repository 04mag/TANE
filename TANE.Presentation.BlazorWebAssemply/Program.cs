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
using TANE.Application.Mappings;

namespace TANE.Presentation.BlazorWebAssemply
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
         



            builder.Services.AddAuthorizationCore();

            //Add layer services
            builder.Services.RegisterApplicationLayer();
            builder.Services.RegisterPersistenceLayer();

            builder.Services.AddRadzenComponents();

            builder.Services.AddScoped<BrowserStorageService>();
            builder.Services.AddRadzenComponents();

            builder.Services.AddScoped<CustomStateProvider>();
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<CustomerState>();


            builder.Services
                .AddAutoMapper(typeof(MappingProfile).Assembly);




            builder.Services.AddScoped<AuthenticationStateProvider>(s =>
                s.GetRequiredService<CustomStateProvider>());


            await builder.Build().RunAsync();
        }
    }
}
