using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.Data                     // Namespace must reflect the right folder
{
    public class Person
    {
        public int Id { get; set; }                     // The Id is only used in the backend, not visible for the client

        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}
