using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace MVCPersonList.Models.ViewModel
{
    public class CreateCountry
    {
        [StringLength(60, MinimumLength = 2)]                                  // In a ViewModel use stringLength instead of MaxLength
        public string CountryName { get; set; }
    }
}
