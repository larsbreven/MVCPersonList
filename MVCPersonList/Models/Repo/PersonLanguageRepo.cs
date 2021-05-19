using MVCPersonList.Database;
using MVCPersonList.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.Repo
{
    public class PersonLanguageRepo : IPersonLanguageRepo
    {
        private readonly PersonListDbContext _personListDbContext;

        public PersonLanguageRepo(PersonListDbContext personListDbContext)
        {
            _personListDbContext = personListDbContext;
        }

        public PersonLanguage Create(PersonLanguage personLanguage)
        {
            _personListDbContext.PersonLanguages.Add(personLanguage);

            if (_personListDbContext.SaveChanges() > 0)
            {
                return personLanguage;
            }

            return null;

        }



        public PersonLanguage Read(int personId, int languageId)
        {
            return _personListDbContext.PersonLanguages.SingleOrDefault(pl => pl.PersonId == personId && pl.LanguageId == languageId);
        }

        public List<PersonLanguage> Read()
        {
            return _personListDbContext.PersonLanguages.ToList();
        }

        public bool Delete(int personId, int languageId)
        {

            PersonLanguage personLanguage = Read(personId, languageId);

            if (personLanguage == null)
            {
                return false;
            }

            _personListDbContext.PersonLanguages.Remove(personLanguage);

            if (_personListDbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }



    }
}
