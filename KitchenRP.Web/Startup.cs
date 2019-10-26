using System;
using System.Linq;
using System.Net;
using KitchenRP.DataAccess;
using KitchenRP.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace KitchenRP.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<KitchenRpContext>(
                cfg =>
                {
                    cfg.UseNpgsql(Configuration.GetConnectionString("default"),
                        b => b
                            .MigrationsAssembly("KitchenRP.Web")
                            .UseNodaTime());
                });

            services.AddScoped<KitchenRpDatabase>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "KitchenRP-Api",
                    Version = "v1",
                });
            });

            services.AddSingleton(provider =>
                new JwtService(Configuration["Jwt:Secret"], int.Parse(Configuration["Jwt:TimeoutDuration"])));

            services.AddKitchenRpDomainServices(c =>
            {
                c.LdapConfiguration(
                    Configuration["Ldap:Host"],
                    ushort.Parse(Configuration["Ldap:Port"]),
                    Configuration["Ldap:SearchBase"],
                    Configuration["Ldap:UserSearch"]
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KitchenRP-API"));
        }
    }
}