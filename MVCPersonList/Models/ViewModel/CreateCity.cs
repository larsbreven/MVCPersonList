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

        [StringLength(60, MinimumLength = 2)]                                  // In a ViewModel use stringLength instead of MaxLength
        public string CityName { get; set; }


        public int CountryId { get; set; }                                      // Only the Id is needed

        public List<Country> CountryList { get; set; }


    }
}
