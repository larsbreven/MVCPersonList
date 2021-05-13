using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.Data
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string CityName { get; set; }


        [ForeignKey("PersonInquestion")]                // This is the solution to include the id in the object and bypass the special naming
        public Person PersonInquestionId { get; set; }  // Id can be used as an integer and be used in the service to fetch the actual personobject and inject it into the viewmodel     
                                                        // If it's not eager loaded the object will be stored in this property PersonInQuestionId and the below property will be null

        // "One" in the "One to many - expression"
        [Required]                                      // Navigational property ==> Possible to navigate from City to Person to another Person-object
        public Person PersonInquestion { get; set; }    // Eager loading will store the object in this property PersonInQuestion

    }
}
