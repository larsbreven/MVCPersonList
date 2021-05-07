using MVCPersonList.Models.Data;
using MVCPersonList.Models.PeopleViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.Service
{
    public interface ICityService
    {
        City Add(CreateCity createCity);                    // "Create"
        List<City> All();                                   // "Read", here is the conversion of a viewmodel to real data
        City FindById(int id);                              // Possible to add more methods in the service layer    

        List<City> FindByCityId(int cityId);                // Find all cities that have the Id of ?? City eller Person
        
        City Edit(int id, CreateCity city);                 // "Update"
        CreateCity CityToCreateCity(City city);
        bool Remove(int id);                                // "Delete"



    }
}
