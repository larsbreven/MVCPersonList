using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Data;
using MVCPersonList.Models.ViewModel;

namespace MVCPersonList.Models.Service
{
    public interface IPersonService                 // Service will do the logic work, filter, sort and so on
    {
        Person Add(CreatePerson createPerson);      // "Create"
        PersonIndexViewModel All();                 // "Read", here is the conversion of a viewmodel to real data
        Person FindByID(int id);                    // Possible to add more methods in the service layer    
        List<Person> FindByCity(string city);       // can be quite big, methods like find city, phone, brand and so on  (Cities can be many = list)
        Person Edit(int id, CreatePerson person);   // "Update"
        CreatePerson PersonToCreatePerson(Person person);
        bool Remove(int id);                        // "Delete"
    }
}
