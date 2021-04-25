using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;            // DataAnnotations added into the file
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.ViewModel
{
    public class CreatePerson
    {
        [Required]                                      // Name is required to type in when creating a person
        [StringLength(100, MinimumLength = 2)]          // Maximum length of a string is 100 characters, 2 is minimum
        public string Name { get; set; }

        [Required]                                      // City is required to type in when creating a person
        [StringLength(100, MinimumLength = 2)]
        public string City { get; set; }

        [Required]                                      // Phone is required to type in when creating a person
        [StringLength(25, MinimumLength = 2)]
        public string Phone { get; set; }

               
        public List<String> PeopleList { get; set; }


        public CreatePerson()
        {
            PeopleList = new List<String>()
            {
            "Andersson",
            "Bengtsson",
            "Carlsson",
            "Danielsson",
            "Eriksson"
            };
        }
    }
}
