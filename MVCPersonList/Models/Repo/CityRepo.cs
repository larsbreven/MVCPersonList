using Microsoft.EntityFrameworkCore;
using MVCPersonList.Database;
using MVCPersonList.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.Repo
{
    public class CityRepo : ICityRepo                                       // Implement ICityRepo
    {

        private readonly PersonListDbContext _personListDbContext;          // Dependency of injection

        public CityRepo(PersonListDbContext personListDbContext)            // This is the connection to the database
        {
            this._personListDbContext = personListDbContext;
        }


        public City Create(City city)
        {
            _personListDbContext.Cities.Add(city);                          

            int result = _personListDbContext.SaveChanges();

            if(result == 0)
            {
                return null;                                                // Not saved correctly in the database
            }

            return city;
        }


        public City Read(int id)
        {
            return _personListDbContext.Cities.Find(id);                    // Same behaviour as SingleOrDefault
        }

        public List<City> Read()
        {
            return _personListDbContext.Cities.Include( row => row.PersonInQuestion).ToList();   //    !!! This can be messy (many to many ==> infinite loop)
            // return _personListDbContext.Cities.ToList();                    // Go to the database and get all the cities and convert it to a list
        }

        public City Update(City city)
        {
            City originCity = Read(city.Id);

            if(originCity == null)
            {
                return null;
            }

            _personListDbContext.Update(city);                              // Transfer the data
            //originCity.CityName = city.CityName;                          // Same command as the simplified version above

            int result = _personListDbContext.SaveChanges();

            if (result == 0)                                                // Check if data is saved
            {
                return null;
            }


            return originCity; 
        }


        public bool Delete(int id)
        {

            City originCity = Read(id);

            if (originCity == null)                             // The id was not correct
            {
                return false;
            }

            _personListDbContext.Cities.Remove(originCity);

            int result = _personListDbContext.SaveChanges();

            if (result == 0)
            {
                return false;
            }

            return true;

        }




    }
}
