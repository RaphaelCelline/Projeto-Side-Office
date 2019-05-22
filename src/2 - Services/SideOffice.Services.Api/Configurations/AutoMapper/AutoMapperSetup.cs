using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace SideOffice.Services.Api.Configurations.AutoMapper
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            // Registro todos os Mappings na application
           Application.AutoMapper.AutoMapperConfig.RegisterMappings();
        }
    }
}
