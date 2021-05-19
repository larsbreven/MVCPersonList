using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Data;

namespace MVCPersonList.Models.Repo
{
    public interface IPeopleRepo
    {
        // Create, read, update or delete a person (C.R.U.D)

        Person Create(Person person);       // Create one person       

        Person Read(int id);                // Read one person, Find By Id

        List<Person> Read();                // Read, get all persons

        Person Update(Person person);       // Update one person

        bool Delete(int id);                // Delete one person

    }
}
