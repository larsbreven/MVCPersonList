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
        public static void Initialize(                          // Update the database
            PersonListDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager
            )
        {
            //context.Database.EnsureCreated();                 // If not using Entity Framework migrations
            context.Database.Migrate();                         // If using Entity Framework Migrations

            if (context.Roles.Any())                            // Check if there are any roles in the datatable => if there are no roles the database is empty
            {
                return;                                         // Assume that the database is seeded because there are roles in it
            }

            // --------------------------------------- All roles and codes below are to be seed into the database ------------------------------------------------------
            // -------------------------------- It is also possible to add in example data for the testing and development phase-----------------------------------
    

            string[] rolesToSeed = new string[] { "Admin", "HumanResources" , "Client" };

            foreach ( var roleName in rolesToSeed)
            {
                string roleAdmin = "Admin";

                IdentityRole role = new IdentityRole(roleAdmin);

                var result = roleManager.CreateAsync(role).Result;

                if (!result.Succeeded)
                {
                    throw new Exception("Failed to create role" + roleAdmin);
                }

            }

            IdentityUser user = new IdentityUser()
            {
                UserName = "AdminPower",
                Email = "a@a.a",
                PhoneNumber = "987654321"
            };

            IdentityResult resultUser = userManager.CreateAsync(user, "Qwerty!23456").Result;        // Be careful = This is a test password, can be visible for everyone

            if (!resultUser.Succeeded)
            {
                throw new Exception("Failed to create Admin Acc: AdminPower");
            }

            IdentityResult resultAssign = userManager.AddToRoleAsync(user, rolesToSeed[0]).Result;

            if (!resultAssign.Succeeded)
            {
                throw new Exception($"Failed to grant {rolesToSeed[0]} role to AdminPower");
            }

        }
    }
}
