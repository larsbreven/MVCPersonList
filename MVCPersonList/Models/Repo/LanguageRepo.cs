using MVCPersonList.Database;
using MVCPersonList.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.Repo
{
    public class LanguageRepo : ILanguageRepo
    {
        private readonly PersonListDbContext _personListDbContext;

        public LanguageRepo(PersonListDbContext personListDbContext)
        {
            _personListDbContext = personListDbContext;
        }

        public Language Create(Language language)
        {
            _personListDbContext.Add(language);

            if (_personListDbContext.SaveChanges() > 0)
            {
                return language;
            }
            return null;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Language Read(int id)
        {
            return _personListDbContext.Languages.SingleOrDefault(language => language.Id == id);
        }

        public List<Language> Read()
        {
            return _personListDbContext.Languages.ToList();
        }

        public Language Update(Language language)
        {
            throw new NotImplementedException();
        }
    }
}
