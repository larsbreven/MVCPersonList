using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.Data
{
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        // Many to many, join table
        public List<PersonLanguage> PersonLanguage { get; set; }    // List of the language per person
    }
}
