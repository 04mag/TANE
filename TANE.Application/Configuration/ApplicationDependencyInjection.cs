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
using TANE.Application.Groups.Users.Commands;
using TANE.Application.Groups.Users.Interfaces;

using TANE.Application.Groups.Kunder.Commands;
using TANE.Application.Groups.Kunder.Commands.Interfaces;
using TANE.Application.Groups.Kunder.Queries;
using TANE.Application.Groups.Kunder.Queries.Interfaces;
using TANE.Application.Groups.RejseplanSkabeloner.Queries.Interfaces;
using TANE.Application.Groups.RejseplanSkabeloner.Queries;
using TANE.Application.Groups.RejseplanSkabeloner.Commands.Interfaces;
using TANE.Application.Groups.RejseplanSkabeloner.Commands;
using TANE.Application.Groups.Dage.Queries.Interfaces;
using TANE.Application.Groups.Dage.Queries;
using TANE.Application.Groups.Rejseplaner.Queries.Interfaces;
using TANE.Application.Groups.Rejseplaner.Queries;
using TANE.Application.Groups.Ture.Queries.Interfaces;
using TANE.Application.Groups.Ture.Queries;
using TANE.Application.Groups.TurSkabeloner.Queries.Interfaces;
using TANE.Application.Groups.TurSkabeloner.Queries;
using TANE.Application.Groups.TurSkabeloner.Commands.Interfaces;
using TANE.Application.Groups.TurSkabeloner.Commands;

namespace TANE.Application.Configuration
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
        {
            //Registrer application services her
            services.AddScoped<IUserLogin, UserLogin>();
            services.AddScoped<IRefreshToken, RefreshToken>();
            services.AddScoped<IRevokeToken, RevokeToken>();
            services.AddScoped<ICreateUser, CreateUser>();
            services.AddScoped<IUpdateUser, UpdateUser>();

            services.AddScoped<ICreateKunde, CreateKunde>();
            services.AddScoped<IReadKunde, ReadKunde>();
            services.AddScoped<IUpdateKunde, UpdateKunde>();
            services.AddScoped<IDeleteKunde, DeleteKunde>();



            services.AddScoped<ICreateDagSkabelon, CreateDagSkabelon>();
            services.AddScoped<IUpdateDagSkabelon, UpdateDagSkabelon>();
            services.AddScoped<IDeleteDagSkabelon, DeleteDagSkabelon>();
            services.AddScoped<IReadDagSkabelon, ReadDagSkabelon>();
           
            services.AddScoped<IReadTurSkabelon, ReadTurSkabelon>();
            services.AddScoped<ICreateTurSkabelon, CreateTurSkabelon>();
            services.AddScoped<IUpdateTurSkabelon, UpdateTurSkabelon>();

            services.AddScoped<IReadRejsePlanSkabelon, ReadRejseplanSkabelon>();
            services.AddScoped<ICreateRejseplanSkabelon, CreateRejseplanSkabelon>();

            services.AddScoped<IReadDag, ReadDag>();
            services.AddScoped<IReadTur, ReadTur>();
            services.AddScoped<IReadRejseplan, ReadRejseplan>();

            return services;
        }
    }
}
