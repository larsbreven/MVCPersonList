using MVCPersonList.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Database;
using Microsoft.EntityFrameworkCore;

namespace MVCPersonList.Models.Repo
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly PersonListDbContext personListDbContext;           // Dependency of injection

        public DatabasePeopleRepo(PersonListDbContext personListDbContext)  // This is the connection to the database
        {
            this.personListDbContext = personListDbContext;   
        }


        public Person Create(Person person)
        {
            personListDbContext.People.Add(person);

            int result = personListDbContext.SaveChanges();

            if (result == 0)                                                // No changes in the database
            {
                throw new Exception("Unable to create a person in the database.");
            }

            return person;                                                  // A person is succesfully created
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Person Read(int id)                                          // When one person is read ("id"), the PersonHistory is included
        {                                   
            return personListDbContext.People.Include(Person => Person.PersonHistory).SingleOrDefault(row => row.Id == id); // If not found return null
        }

        public List<Person> Read()
        {
            return personListDbContext.People.ToList();
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
