using MVCPersonList.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.Repo
{
    public interface ICityRepo
    {

        // Create, read, update or delete a person (C.R.U.D)

        City Create(City city);         // Create a city       


        City Read(int id);              // Read one city, Find By Id

        List<City> Read();              // Read, get all cities


        City Update(City city);         // Update one city


        bool Delete(int id);            // Delete one city
    }
}
