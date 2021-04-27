using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Data;

namespace MVCPersonList.Models.ViewModel
{
    public class PersonIndexViewModel                           // Container for the information needed in people view
    {
        public string FilterText { get; set; }

        public List<Person> PersonList { get; set; }

        public CreatePerson CreatePerson { get; set; }
    }
}
