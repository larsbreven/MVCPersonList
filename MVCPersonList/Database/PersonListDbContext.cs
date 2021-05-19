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

        //Join table configured using Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonLanguage>().HasKey(pl =>
            new {
                pl.PersonId,
                pl.LanguageId
            });

            //modelBuilder.Entity<City>()
            //    .HasMany(c => c.PersonsInCity)
            //    .WithOne(p => p.InCity)
            //    .HasForeignKey(p => p.InCityId);

            //modelBuilder.Entity<Person>()
            //    .HasOne<City>(p => p.InCity)
            //    .WithMany(c => c.PersonsInCity);


            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Person>(pl => pl.Person)        // pl = PersonLanguage  
                .WithMany(p => p.PersonLanguages)        // p = Person
                .HasForeignKey(pl => pl.PersonId);      // l = Language

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Language>(pl => pl.Language)
                .WithMany(l => l.PersonLanguage)
                .HasForeignKey(pl => pl.LanguageId);

        }

        public DbSet<Person> People { get; set; }       // By default DBSet is private, remember to change it to public
                                                        // The columns are structured according to <Person>  
        public DbSet<City> Cities { get; set; }         // People and cities is the tablename

        public DbSet<Country> Countries { get; set; }   // Countries is the tablename

        public DbSet<Language> Languages { get; set; }  // Languages is the tablename

        public DbSet<PersonLanguage> PersonLanguages { get; set; }   // PersonLanguage is the tablename

        public DbSet<PersonGroup> PersonGroups { get; set; }    // PersonGroup is the tablename
    }
}
