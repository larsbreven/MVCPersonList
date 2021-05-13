using Microsoft.EntityFrameworkCore;                    // Needed for DbContext
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Data;

namespace MVCPersonList.Database
{
    public class PersonListDbContext : DbContext        // This is the connection to the database              
    {

        public PersonListDbContext(DbContextOptions<PersonListDbContext> options) : base(options)
        { }

        public DbSet<Person> People { get; set; }       // By default DBSet is private, remember to change it to public
                                                        // The columns are structured according to <Person>  
        public DbSet<City> Cities { get; set; }         // People and cities is the tablename

        public DbSet<PersonGroup> PersonGroups { get; set; }    // PersonGroup is the tablename
    }
}
