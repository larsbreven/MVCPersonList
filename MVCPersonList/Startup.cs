using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList
{
    public class Startup
    {
        public Startup(IConfiguration configuration)            // The IConfiguration is used to get access to appsettings.json
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
