using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Data;

namespace MVCPersonList.Models.Repo
{
    public interface ILanguageRepo
    {
        // Create, read, update or delete a person (C.R.U.D)

        Language Create(Language language);     // Create one language       

        Language Read(int id);                  // Read one language, Find By Id

        List<Language> Read();                  // Read, get all languages

        Language Update(Language language);     // Update one language

        bool Delete(int id);                    // Delete one language
    }
}
