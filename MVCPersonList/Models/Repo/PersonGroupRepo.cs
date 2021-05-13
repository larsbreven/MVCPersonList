using MVCPersonList.Database;
using MVCPersonList.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.Repo
{
    public class PersonGroupRepo : IPersonGroupRepo
    {
        private readonly PersonListDbContext _personListDbContext;

        public PersonGroupRepo(PersonListDbContext personListDbContext)
        {
            this._personListDbContext = personListDbContext;
        }


        public PersonGroup Create(PersonGroup personGroup)
        {
            _personListDbContext.PersonGroups.Add(personGroup);

            int result = _personListDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return personGroup;
        }

        public PersonGroup Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<PersonGroup> Read()
        {
            throw new NotImplementedException();
        }

        public PersonGroup Update(PersonGroup personGroup)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
