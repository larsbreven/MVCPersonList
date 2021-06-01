using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Database
{
    public class DbInitializer
    {
        public static void Initialize(
            PersonListDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager
            )
        {
            //context.Database.EnsureCreated();
            //If not using EF migrations
            context.Database.Migrate();

            if (context.Roles.Any())
            {
                return;             // Assume that the database is seeded because there are roles in it
            }

            // ------------------------------ Seed into database ------------------------------------------------------

            string roleAdmin = "Admin";

            IdentityRole role = new IdentityRole(roleAdmin);

            var result = roleManager.CreateAsync(role).Result;

            if ( ! result.Succeeded)
            {
                throw new Exception("Failed to create role" + roleAdmin);
            }

            string roleHumanResources = "HumanResources";

            IdentityRole roleHR = new IdentityRole(roleHumanResources);

            result = roleManager.CreateAsync(roleHR).Result;

            if (!result.Succeeded)
            {
                throw new Exception("Failed to create role" + roleHumanResources);
            }

        }
    }
}
