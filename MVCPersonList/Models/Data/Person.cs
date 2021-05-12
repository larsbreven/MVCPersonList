using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.Data                     // Namespace must reflect the right folder
{
    public class Person
    {
        [Key]                                           // Data annotations is added, int ID is the Key
        public int Id { get; set; }                     // The Id is only used in the backend, not visible for the client

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
                
        [Required]
        [MaxLength(100)]
        public string City { get; set; }

      
        [MaxLength(25)]
        public string Phone { get; set; }

    }
}
