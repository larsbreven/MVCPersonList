using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Data;
using MVCPersonList.Models.Repo;
using MVCPersonList.Models.ViewModel;

namespace MVCPersonList.Models.Service
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _personRepo;                             // Storage for person data

        public PeopleService()
        {
            _personRepo = new InMemoryPeopleRepo();
        }

        public Person Add(CreatePerson createPerson)        // Service will do the conversion
        {
            Person person = new Person();

            person.Name = createPerson.Name;
            person.City = createPerson.City;
            person.Phone = createPerson.Phone;

            person = _personRepo.Create(person);

            return person;                                  // The person is returned with the right Id
        }

        public PersonIndexViewModel All()
        {
            PersonIndexViewModel indexViewModel = new PersonIndexViewModel();

            indexViewModel.PersonList = _personRepo.Read();

            return indexViewModel;
        }

        public Person FindByID(int id)
        {
            return _personRepo.Read(id);
        }

        public List<Person> FindByCity(string name)                     // Filter out the name of the people
        {
            List<Person> personNameList = new List<Person>();

            foreach (Person item in _personRepo.Read())                 // Read in all the persons
            {
                if (item.Name.Equals(name))                             // Sort out the matching persons                         
                {
                    personNameList.Add(item);
                }
            }

            return personNameList;                                      // Return the list with the matching cities
        }


        public Person Edit(int id, CreatePerson person)
        {
            Person originPerson = FindByID(id);

            if (originPerson == null)                                   // No person to update -- not even the "origin" person
            {
                return null;

            }

            originPerson.Name = person.Name;
            originPerson.City = person.City;
            originPerson.Phone = person.Phone;

            originPerson = _personRepo.Update(originPerson);

            return originPerson;
        }

        public bool Remove(int id)
        {
            return _personRepo.Delete(id);
        }

        public CreatePerson PersonToCreatePerson(Person person)
        {
            CreatePerson createPerson = new CreatePerson();

            createPerson.Name = person.Name;
            createPerson.City = person.City;
            createPerson.Phone = person.Phone;

            return createPerson;
        }
    }
}
