﻿using System;
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
        IPeopleRepo _peopleRepo;                             // Storage for person data

        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        public Person Add(CreatePerson createPerson)        // Service will do the conversion
        {
            Person person = new Person();

            person.Name = createPerson.Name;
            person.City = createPerson.City;
            person.Phone = createPerson.Phone;

            person = _peopleRepo.Create(person);

            return person;                                  // The person is returned with the right Id
        }

        public PersonIndexViewModel All()
        {
            PersonIndexViewModel indexViewModel = new PersonIndexViewModel();

            indexViewModel.PersonList = _peopleRepo.Read();

            return indexViewModel;
        }

        public Person FindById(int id)
        {
            return _peopleRepo.Read(id);
        }

        public List<Person> FindByName(string name)                     // Filter out the searched name of the person
        {
            List<Person> personNameList = new List<Person>();           // Create the filtered list

            foreach (Person item in _peopleRepo.Read())                 // _personRepo will read in all the persons
            {
                if (item.Name.Equals(name))                             // Sort out the filtered matching person                         
                {
                    personNameList.Add(item);                           // Add the person to the list
                }
            }

            return personNameList;                                      // Return the list with the matching person
        }


        public Person Edit(int id, CreatePerson person)
        {
            Person originPerson = FindById(id);

            if (originPerson == null)                                   // No person to update -- not even the "origin" person
            {
                return null;

            }

            originPerson.Name = person.Name;
            originPerson.City = person.City;
            originPerson.Phone = person.Phone;

            originPerson = _peopleRepo.Update(originPerson);

            return originPerson;
        }

        public bool Remove(int id)
        {
            return _peopleRepo.Delete(id);
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
