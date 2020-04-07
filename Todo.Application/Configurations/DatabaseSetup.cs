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

            services.AddDbContext<MysqlContext>(options =>
                options.UseInMemoryDatabase("Database"));
            
            //Add Mysql connection
            // services.AddDbContext<MysqlContext>(options =>
            //     options.UseMySql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
