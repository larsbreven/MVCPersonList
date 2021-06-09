using MVCPersonList.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Database;
using Microsoft.EntityFrameworkCore;

namespace MVCPersonList.Models.Repo
{
    public class PeopleRepo : IPeopleRepo
    {
        private readonly PersonListDbContext personListDbContext;           // Dependency of injection

        public PeopleRepo(PersonListDbContext personListDbContext)          // This is the connection to the database
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

            return person;                                                  // A person is successfully created
        }


        public Person Read(int id)                                          // When one person is read ("id"), the PersonHistory is included
        {
            return personListDbContext.People.Include(Person => Person.InCity)
                                             .Include(person => person.PersonLanguages)
                                             .ThenInclude(perLan => perLan.Language)
                                             .SingleOrDefault(row => row.Id == id); // If not found return null
        }
        public List<Person> Read()
        {
            return personListDbContext.People.ToList();
        }


        public Person Update(Person person)
        {
            Person originPerson = Read(person.Id);

            if (originPerson == null)
            {
                return null;
            }

            personListDbContext.Update(person);                              // Transfer the data
            //originCity.CountryName = country.CountryName;                  // Same command as the simplified version above

            int result = personListDbContext.SaveChanges();

            if (result == 0)                                                // Check if data is saved
            {
                return null;
            }

            return originPerson;
        }
          

        public bool Delete(int id)
        {
            Person originPerson = Read(id);

            if (originPerson == null)                                       // The id was not correct
            {
                return false;
            }

            personListDbContext.People.Remove(originPerson);

            int result = personListDbContext.SaveChanges();

            if (result == 0)                                                // No changes in the database
            {
                return false;
            }

            return true;                                                    // A person is succesfully deleted
        }
    }
}