using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPersonList.Models.Data                     // Namespace must reflect the right folder
{
    public class Person
    {
        [Key]                                           // Data annotations is added, int ID is the Key
        public int Id { get; set; }                     // The Id is only used in the backend, not visible for the client

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public City InCity { get; set; }

        [ForeignKey("InCity")]
        public int InCityId { get; set; }


        [MaxLength(25)]
        public string Phone { get; set; }

        // "Many" in the "Many to one - expression"

        //public List<City> PersonHistory { get; set; }       // Navigational property ==> Possible to navigate from Person to City to another City-object

        // Many to many, join table
        public List<PersonLanguage> PersonLanguages { get; set; }    // List of the language per person
    }

}
