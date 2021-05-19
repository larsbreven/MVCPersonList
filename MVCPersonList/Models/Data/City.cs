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

        [MaxLength(60)]
        public string CityName { get; set; }


        public List<Person> PersonsInCity { get; set; }

        public Country Country { get; set; }
    }
}
