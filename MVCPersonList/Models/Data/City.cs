using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string NewMayor { get; set; }

        [Required]
        [MaxLength(60)]
        public string CurrentMayor { get; set; }

        [Required]
        public DateTime RegistTimeNewMayor { get; set; }

        
    }
}
