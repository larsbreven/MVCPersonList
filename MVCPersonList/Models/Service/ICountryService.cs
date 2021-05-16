using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Data;
using MVCPersonList.Models.ViewModel;

namespace MVCPersonList.Models.Service
{
    public interface ICountryService
    {
        Country Add(CreateCountry CreateCountry);             // "Create"
        List<Country> All();                                    // "Read", here is the conversion of a viewmodel to real data
        Country FindById(int id);                               // Possible to add more methods in the service layer    

        Country Edit(int id, CreateCountry country);          // "Update"
        bool Remove(int id);                                    // "Delete"



    }
}
