using MVCPersonList.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.ViewModel
{
    public class CreateCity
    {
        [Required]
        [StringLength(60, MinimumLength = 2)]                                  // In a ViewModel use stringLength instead of MaxLength
        public string CityName { get; set; }

        [Required]
        public int PersonInQuestionId { get; set; }                             // Only the Id is needed
            
        public List<Person> PersonList { get; set; }


    }
}
