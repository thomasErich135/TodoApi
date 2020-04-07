using System;
using Microsoft.Extensions.DependencyInjection;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;
using Todo.Infrastructure.Repositories;

namespace Todo.Application.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //Repositories
            
            services.AddTransient<ITodoRepository,TodoRepository>();

            //Handlers
            services.AddTransient<TodoHandler,TodoHandler>();

            return services;
        }
    }
}
