using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Data;

namespace MVCPersonList.Models.Repo
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        static List<Person> personList = new List<Person>();
        static int idCounter = 0;

        public InMemoryPeopleRepo()         // List of default persons can be added
        {
            if (personList.Count == 0)
            {
                personList.Add(new Person() { Id = 1, Name = "Antonia", City = "Alicante", Phone = "123" });
                personList.Add(new Person() { Id = 2, Name = "Britney", City = "Baltimore", Phone = "456" });
                personList.Add(new Person() { Id = 3, Name = "Carol", City = "Cincinnati", Phone = "789" });
            }
        }

        public Person Create(Person person)
        {
            person.Id = ++idCounter;        // The person gets the unique Id, this is a new person
            personList.Add(person);         // Make sure the person is added to the list

            return person;                  // The persons now got an ID they didn't had before
        }

        public Person Read(int id)
        {
            foreach (Person item in personList)
            {
                if (item.Id == id)          // If the Person Id match what is read in
                {
                    return item;            // the person is found
                }
            }
            return null;                    // There is no person in the whole list with the id presented, return null
        }

        public List<Person> Read()
        {
            return personList;
        }

        public Person Update(Person person)
        {

            Person originPerson = Read(person.Id);       // Make sure the person exist, not possible to update a non-existing person 

            if (originPerson == null)
            {
                return null;                            // The person does not exist 
            }

            originPerson.Name = person.Name;
            originPerson.City = person.City;
            originPerson.Phone = person.Phone;

            return originPerson;                        // The origin person with updated information

        }


        public bool Delete(int id)
        {
            Person person = Read(id);

            if (person == null)                         // Not possible to remove aperson that does not exist            
            {
                return false;                            // The person does not exist 
            }

            return personList.Remove(person);
        }
    }
}
