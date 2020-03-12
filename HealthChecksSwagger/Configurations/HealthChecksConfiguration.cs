using HealthChecks.UI.Client;
using HealthChecksSwagger.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace HealthChecksSwagger.Configurations
{
    public static class HealthChecksConfiguration
    {
        public static IServiceCollection AddCustomSqlServerHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<AuthenticationContext>()
                .AddDbContextCheck<OrderContext>();

            services.AddHealthChecksUI();

            return services;
        }

        public static IApplicationBuilder UseCustomHealthChecks(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/status-api", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(opt =>
            {
                opt.UIPath = "/status-dashboard";
            });

            return app;
        }

        public static IApplicationBuilder UseCustomHealthChecksWriter(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/status", new HealthCheckOptions()
            {
                ResponseWriter = (httpContext, result) =>
                {
                    httpContext.Response.ContentType = "application/json";

                    var json = new JObject(
                        new JProperty("status", result.Status.ToString()),
                        new JProperty("results", new JObject(result.Entries.Select(pair =>
                            new JProperty(pair.Key, new JObject(
                                new JProperty("status", pair.Value.Status.ToString()),
                                new JProperty("description", pair.Value.Description),
                                new JProperty("data", new JObject(pair.Value.Data.Select(
                                    p => new JProperty(p.Key, p.Value))))))))));

                    return httpContext.Response.WriteAsync(json.ToString(Formatting.Indented));
                }
            });

            return app;
        }
    }
}
