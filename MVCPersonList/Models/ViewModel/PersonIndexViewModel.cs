using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Data;

namespace MVCPersonList.Models.ViewModel
{
    public class PersonIndexViewModel
    {
        public string FilterText { get; set; }

        public List<Person> PersonList { get; set; }
    }
}
