using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.DagSkabeloner.Commands;
using TANE.Application.Groups.DagSkabeloner.Commands.Interfaces;
using TANE.Application.Groups.DagSkabeloner.Queries;
using TANE.Application.Groups.DagSkabeloner.Queries.Interfaces;
using TANE.Application.Groups.JwtTokens.Commands;
using TANE.Application.Groups.JwtTokens.Commands.Interfaces;
using TANE.Application.Groups.Kunder.Commands;
using TANE.Application.Groups.Kunder.Commands.Interfaces;

namespace TANE.Application.Configuration
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
        {
            //Registrer application services her
            services.AddScoped<IUserLogin, UserLogin>();
            services.AddScoped<IRefreshToken, RefreshToken>();



            services.AddScoped<ICreateKunde, CreateKunde>();

            services.AddScoped<ICreateDagSkabelon, CreateDagSkabelon>();
            services.AddScoped<IUpdateDagSkabelon, UpdateDagSkabelon>();
            services.AddScoped<IDeleteDagSkabelon, DeleteDagSkabelon>();
            services.AddScoped<IReadDagSkabelon, ReadDagSkabelon>();

            return services;
        }
    }
}
