using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.Data
{
    public class PersonLanguage                     // Join table also named association table or relational table
    {
        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}                                                   // Many - to - many
