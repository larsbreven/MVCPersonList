using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCPersonList.Database;
using MVCPersonList.Models.Data;
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
            // -------------------------------------------------- Connection to database --------------------------------------------------
            services.AddDbContext<PersonListDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // -------------------------------------------------- Identity ----------------------------------------------------------------
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<PersonListDbContext>()
                .AddDefaultTokenProviders();                                    // This one can be replaced with jbt-token in React

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            // --------------------------------------- Services Inversion of Control ------------------------------------------------------
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ILanguageService, LanguageService>();

            // --------------------------------------- Repository Inversion of Control ----------------------------------------------------
            // services.AddSingleton<IPeopleRepo, InMemoryPeopleRepo>();        // InMemory version
            services.AddScoped<IPeopleRepo, PeopleRepo>();                      // Database version PeopleRepo
            services.AddScoped<ICityRepo, CityRepo>();                          // Database version CityRepo
            services.AddScoped<ICountryRepo, CountryRepo>();                    // Database version CountryRepo
            services.AddScoped<IPersonGroupRepo, PersonGroupRepo>();            // Database version PersonGroupRepo
            services.AddScoped<ILanguageRepo, LanguageRepo>();                  // Database version PersonGroupRepo
            services.AddScoped<IPersonLanguageRepo, PersonLanguageRepo>();      // Database version PersonLanguageGroupRepo

            // ----------------------------------------------------- CORS -----------------------------------------------------------------

            services.AddCors(options =>
            {

                options.AddPolicy("ReactPolicy",
                    builder =>
                    {
                        builder.WithOrigins("*")                                // "*" is like saying any and all are okay
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

            // ---------------------------------------------------- Swagger -----------------------------------------------------------------

            services.AddSwaggerGen();

                       // services.AddMVC() is used instead of this: services.AddControllersWithViews();
            services.AddMvc();

        }


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

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Person API V1");
            });


            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();                        // Are you logged in?
            app.UseAuthorization();                         // Do you have the right to log in?

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
