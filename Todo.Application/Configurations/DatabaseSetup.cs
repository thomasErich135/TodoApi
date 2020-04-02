using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Infrastructure.Context;

namespace Todo.Application.Configurations
{
    public static class DatabaseSetup
    {
        public static IServiceCollection AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            //Add Mysql connection
            string teste = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<TodoContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
