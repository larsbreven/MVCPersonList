using MVCPersonList.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.ViewModel
{
    public class PersonLanguagesVM
    {
        public Person Person { get; set; }

        public List<Language> Languages { get; set; }   // The list will have the languages the person don't have
    }
}
