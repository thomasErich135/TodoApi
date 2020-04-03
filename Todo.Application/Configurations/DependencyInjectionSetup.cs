using System;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Application.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            return services;
        }
    }
}
