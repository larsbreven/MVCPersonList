using MVCPersonList.Models.Data;
using MVCPersonList.Models.Repo;
using MVCPersonList.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.Service
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepo _languageRepo;

        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }
        public Language Add(CreateLanguage createLanguage)
        {
            Language language = new Language() { Name = createLanguage.Name };
            return _languageRepo.Create(language);
        }

        public List<Language> All()
        {
            return _languageRepo.Read();
        }


        public Language FindById(int id)
        {
            return _languageRepo.Read(id);
        }


        public Language Edit(int id, CreateLanguage language)
        {
            throw new NotImplementedException();
        }

      

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
