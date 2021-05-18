using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Service;
using MVCPersonList.Models.ViewModel;
using MVCPersonList.Models.Repo;
using MVCPersonList.Models.Data;


namespace MVCPersonList.Models.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepo _countryRepo;
        private readonly ICityRepo _cityRepo;

        public CountryService(ICountryRepo countryRepo, ICityRepo cityRepo)
        {
            _countryRepo = countryRepo;
            _cityRepo = cityRepo;
        }
        public Country Add(CreateCountry CreateCountry)
        {
            Country country = new Country();
            country.CountryName = CreateCountry.CountryName;

            return _countryRepo.Create(country);
        }

        public List<Country> All()
        {
            return _countryRepo.Read();
        }

        public Country FindbyId(int id)
        {
            return _countryRepo.Read(id);
        }
        public Country Edit(int id, CreateCountry country)
        {
            Country originCountry = FindbyId(id);
            if (originCountry == null)
            {
                return null;
            }
            originCountry.CountryName = country.CountryName;
            originCountry = _countryRepo.Update(originCountry);

            return originCountry;
        }


        public bool Remove(int id)
        {
            return _countryRepo.Delete(id);
        }

        
    }
}
