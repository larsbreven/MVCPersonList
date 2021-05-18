using System;
using MVCPersonList.Models.Data;
using MVCPersonList.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.Service
{
    public interface ILanguageService
    {

        Language Add(CreateLanguage createLanguage);            // "Create"
        List<Language> All();                                   // "Read", here is the conversion of a viewmodel to real data
        Language FindById(int id);                              // Possible to add more methods in the service layer    

        Language Edit(int id, CreateLanguage language);         // "Update"
        bool Remove(int id);                                    // "Delete"


    }
}
