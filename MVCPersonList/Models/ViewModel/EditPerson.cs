using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.ViewModel
{
    public class EditPerson
    {
        public int Id { get; set; }
        public CreatePerson CreatePerson { get; set; }
    }
}
