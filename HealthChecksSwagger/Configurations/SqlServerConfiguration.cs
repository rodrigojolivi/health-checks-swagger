using HealthChecksSwagger.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthChecksSwagger.Configurations
{
    public static class SqlServerConfiguration
    {
        public static IServiceCollection AddCustomSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthenticationContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("AuthenticationConnection")));

            services.AddDbContext<OrderContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("OrderConnection")));

            return services;
        }
    }
}
