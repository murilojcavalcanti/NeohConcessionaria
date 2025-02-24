using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeohConcessionaria.Infra.Persistence;
using NeohConcessionaria.Infra.Repositories;
using NeohConcessionaria.Infrastructure.Repositories;
using NeohConcessionaria.Infrastructure.Repositories.Fabricantes;

namespace NeohConcessionaria.Infrastructure
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfrasctructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddData(configuration).AddRepositories(configuration);
            return services;
        }

        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            string conString = configuration.GetConnectionString("ConcessionariaApp");
            services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(conString));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IFabricanteRepository, FabricanteRepository>();
            return services;
        }
    }
}
