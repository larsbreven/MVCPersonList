using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Data;
using MVCPersonList.Models.Repo;

namespace MVCPersonList.Models.Repo
{
    interface ICountryRepo
    {
        // Create, read, update or delete a country (C.R.U.D)

        Country Create(Country country);    // Create one country       

        Country Read(int id);               // Read one country, Find By Id

        List<Country> Read();               // Read, get all countries

        Country Update(Country country);    // Update one country

        bool Delete(int id);                // Delete one country


    }
}
