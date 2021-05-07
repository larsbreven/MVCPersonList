using MVCPersonList.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.PeopleViewModel
{
    public class CreateCity
    {
        [Required]
        [StringLength(60, MinimumLength = 2)]                                  // In a ViewModel use stringLength instead of MaxLength
        public string NewMayor { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2)]                                   // In a ViewModel use stringLength instead of MaxLength
        public string CurrentMayor { get; set; }

        public List<Person> PersonList { get; set; }
    }
}
