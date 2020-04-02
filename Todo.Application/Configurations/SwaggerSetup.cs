using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Todo.Application.Configurations
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwaggerSetup (this IServiceCollection services)
        {
            services.AddSwaggerGen(s => {
                s.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "TODO API",
                        Version = "v1",
                        Description = "API para o projeto TODO APP(Registro de tarefas)",
                        Contact = new OpenApiContact
                        { Email = "martinsoliveira.marcelo@outlook.com", Name = "Marcelo Martins" }
                    });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerSetup(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TODO API V1");
                c.RoutePrefix = string.Empty;
            });
            return app;
        }
    }
}
