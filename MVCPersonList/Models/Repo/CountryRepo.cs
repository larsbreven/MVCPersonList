using Microsoft.EntityFrameworkCore;
using MVCPersonList.Database;
using MVCPersonList.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Repo;
using MVCPersonList.Models.Service;

namespace MVCPersonList.Models.Repo
{
    public class CountryRepo : ICountryRepo
    {

        private readonly PersonListDbContext _personListDbContext;          // Dependency of injection

        public CountryRepo(PersonListDbContext personListDbContext)            // This is the connection to the database
        {
            this._personListDbContext = personListDbContext;
        }


        public Country Create(Country country)
        {
            _personListDbContext.Countries.Add(country);

            int result = _personListDbContext.SaveChanges();

            if (result == 0)
            {
                return null;                                                // Not saved correctly in the database
            }

            return country;
        }


        public Country Read(int id)
        {
            return _personListDbContext.Countries.Find(id);                    // Same behaviour as SingleOrDefault
        }

        public List<Country> Read()
        {
            return _personListDbContext.Countries.Include(country => country.CityInCountry).ToList();   //    !!! This can be messy (many to many ==> infinite loop)
            //     return _personListDbContext.Cities.ToList();                    // Go to the database and get all the cities and convert it to a list
        }

        public Country Update(Country country)
        {
            Country originCountry = Read(country.Id);

            if (originCountry == null)
            {
                return null;
            }

            _personListDbContext.Update(country);                              // Transfer the data
            //originCity.CountryName = country.CountryName;                          // Same command as the simplified version above

            int result = _personListDbContext.SaveChanges();

            if (result == 0)                                                // Check if data is saved
            {
                return null;
            }


            return originCountry;
        }


        public bool Delete(int id)
        {

            Country originCountry = Read(id);

            if (originCountry == null)                             // The id was not correct
            {
                return false;
            }

            _personListDbContext.Countries.Remove(originCountry);

            int result = _personListDbContext.SaveChanges();

            if (result == 0)
            {
                return false;
            }

            return true;

        }



    }
}
