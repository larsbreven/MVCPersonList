using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCPersonList.Database;
using MVCPersonList.Models.Repo;
using MVCPersonList.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList
{
    public class Startup
    {

        private readonly IConfiguration Configuration;          // The property for startup

        public Startup(IConfiguration config)                  // The configuration is used to get access to appsettings.json
        {
            Configuration = config;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PersonListDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IPeopleService, PeopleService>();
            // services.AddSingleton<IPeopleRepo, InMemoryPeopleRepo>();        // InMemory version
            services.AddScoped<IPeopleRepo, DatabasePeopleRepo>();              // Database version

            // service.AddMVC() is used instead of this: services.AddControllersWithViews();
            services.AddMvc();

        }
        // ---------------------------------------------------------------------------------------------------------------------------------


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())                        // Used under development
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {                                               // Not used under development
                                                            // The default HSTS value is 30 days https://aka.ms/aspnetcore-hsts.
                app.UseHsts();                              // Mandatory to use for security (https)
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();                           // The static files in www.root including bootstrap and favicon

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
