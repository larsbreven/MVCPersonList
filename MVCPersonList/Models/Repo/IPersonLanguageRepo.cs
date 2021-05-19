using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Data;

namespace MVCPersonList.Models.Repo
{
    public interface IPersonLanguageRepo
    {
        PersonLanguage Create(PersonLanguage personLanguage);

        PersonLanguage Read(int personId, int langaugeId);

        List<PersonLanguage> Read();

        bool Delete(int personId, int langaugeId);
    }
}
