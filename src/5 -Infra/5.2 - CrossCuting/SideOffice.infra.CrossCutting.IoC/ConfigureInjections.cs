using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SideOffice.Application.AppServices;
using SideOffice.Application.Interfaces;
using SideOffice.Domain.Interfaces.Repositories;
using SideOffice.Domain.Interfaces.Services;
using SideOffice.Domain.Services;
using SideOffice.Infra.Data.Context;
using SideOffice.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.infra.CrossCutting.IoC
{
    public class ConfigureInjections
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IRoomAppService, RoomAppService>();
            services.AddScoped<IRentAppService, RentAppService>();

            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRentService, RentService>();

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
        }
    }
}
