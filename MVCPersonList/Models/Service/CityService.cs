using MVCPersonList.Models.Data;
using MVCPersonList.Models.ViewModel;
using MVCPersonList.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.Service
{
    public class CityService : ICityService
    {
        private readonly ICityRepo _cityRepo;
        private readonly IPeopleRepo _peopleRepo;

        public CityService(ICityRepo cityRepo, IPeopleRepo peopleRepo)
        {
            _cityRepo = cityRepo;
            _peopleRepo = peopleRepo;
        }

        public City Add(CreateCity createCity)              // CreateCity is the class, createCity is the ViewModel
        {
            City city = new City();                         // A "blank" city is created

            city.CityName = createCity.CityName;            // In this section add additional validations and checks
          //  city.PersonInQuestion = _peopleRepo.Read(createCity.PersonInQuestionId);    // Using peopleRepo and the PersonInQuestionId to put in the right city based on the Id

            return _cityRepo.Create(city);
        }

        public List<City> All()
        {
            return _cityRepo.Read();
        }

        public City Edit(int id, CreateCity city)
        {
            throw new NotImplementedException();
        }

        public List<City> FindByCityId(int cityId)
        {
            throw new NotImplementedException();
        }

        public City FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public CreateCity CityToCreateCity(City city)
        {
            throw new NotImplementedException();
        }

    }
}
