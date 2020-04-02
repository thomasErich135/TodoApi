using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Linq;
using System;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;

namespace Todo.Application.Configurations
{
    public static class HealthCheckSetup
    {
        public static IServiceCollection AddHealthCheckSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddMySql(configuration.GetConnectionString("DefaultConnection"),
                          "Base Sql", null, null, TimeSpan.FromSeconds(5))
                .AddUrlGroup(new Uri("https://www.google.com/"),
                          "Google connection",null,null, TimeSpan.FromSeconds(14));
            services.AddHealthChecksUI();
            return services;
        }

        public static IApplicationBuilder UseHealthCheckSetup(this IApplicationBuilder app)
        {
            // Ativando o middlweare de Health Check
            app.UseHealthChecks("/status",
               new HealthCheckOptions()
               {
                   ResponseWriter = async (context, report) =>
                   {
                       var result = JsonConvert.SerializeObject(
                           new
                           {
                               statusApplication = report.Status.ToString(),
                               healthChecks = report.Entries.Select(e => new
                               {
                                   check = e.Key,
                                   ErrorMessage = e.Value.Exception?.Message,
                                   status = Enum.GetName(typeof(HealthStatus), e.Value.Status)
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
