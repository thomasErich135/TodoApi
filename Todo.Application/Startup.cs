using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Todo.Application.Configurations;

namespace Todo.Application
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            //Database Setup
            services.AddDatabaseSetup(Configuration);

            //Dependency Injection
            services.AddDependencyInjectionSetup();

            //Swagger Setup
            services.AddSwaggerSetup();

            //HealthCheck Setup
            services.AddHealthCheckSetup(Configuration);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Swagger using
            app.UseSwaggerSetup();

            // //HealthCheck using
            app.UseHealthCheckSetup();

            app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(x => x
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());

           
            app.UseEndpoints(endpoints =>
            {   
                endpoints.MapControllers();
            });
        }
    }
}
