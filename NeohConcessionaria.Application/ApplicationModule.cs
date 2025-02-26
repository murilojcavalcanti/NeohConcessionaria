using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeohConcessionaria.Infra.Persistence;
using NeohConcessionaria.Infra.Repositories.Concessionarias;
using NeohConcessionaria.Infra.Repositories.Veiculos;
using NeohConcessionaria.Infra.Repositories.Vendas;
using NeohConcessionaria.Infra.Repositories;
using NeohConcessionaria.Infrastructure.Repositories.Fabricantes;
using NeohConcessionaria.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeohConcessionaria.Application.Services.FabricanteServices;
using NeohConcessionaria.Application.Services.ConcessionariaService;
using NeohConcessionaria.Application.Services.ConcessionariaServices;

namespace NeohConcessionaria.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices();
            return services;
        }


        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFabricanteService, FabricanteService>();
            services.AddScoped<IConcessionariaService, ConcessionariaService>();
            return services;
        }
    }
}
