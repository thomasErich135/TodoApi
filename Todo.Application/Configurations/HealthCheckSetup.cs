using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Linq;
using System;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using HealthChecks.UI.Client;

namespace Todo.Application.Configurations
{
    public static class HealthCheckSetup
    {
        //TODO
        public static IServiceCollection AddHealthCheckSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                    .AddMySql(configuration.GetConnectionString("DefaultConnection"),"Database");
            services.AddHealthChecksUI();
            return services;
        }

        //TODO
        public static IApplicationBuilder UseHealthCheckSetup(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/status",
               new HealthCheckOptions()
               {
                   ResponseWriter = async (context, report) =>
                   {
                       var result = JsonConvert.SerializeObject(
                           new
                           {
                               statusApplication = report.Status.ToString(),
                               totalCheckDuratin = report.TotalDuration.TotalSeconds.ToString("0:0.00"),
                               healthChecks = report.Entries.Select(e => new
                               {
                                   check = e.Key,
                                   ErrorMessage = e.Value.Exception?.Message,
                                   status = Enum.GetName(typeof(HealthStatus), e.Value.Status),
                                   duration = e.Value.Duration.TotalSeconds.ToString("0:0.00")
                               })
                           });
                       context.Response.ContentType = MediaTypeNames.Application.Json;
                       await context.Response.WriteAsync(result);
                   }
                });
            
            // Gera o endpoint que retornará os dados utilizados no dashboard
            app.UseHealthChecks("/healthchecks-data-ui", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            // Ativa o dashboard para a visualização da situação de cada Health Check
            app.UseHealthChecksUI();

            return app;
        }
    }
}
