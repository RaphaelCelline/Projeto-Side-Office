using Microsoft.Extensions.DependencyInjection;
using SideOffice.infra.CrossCutting.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SideOffice.UI.WEB.Configurations.Dependences
{
    public class DependenceSetup
    {
        public static void RegisterInService(IServiceCollection services)
        {
            ConfigureInjections.RegisterServices(services);
        }
    }
}
