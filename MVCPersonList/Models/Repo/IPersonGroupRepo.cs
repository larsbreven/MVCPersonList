using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPersonList.Models.Data;

namespace MVCPersonList.Models.Repo
{
    public interface IPersonGroupRepo
    {
        //C.R.U.D.
        PersonGroup Create(PersonGroup personGroup);

        PersonGroup Read(int id);//Find By Id
        List<PersonGroup> Read();// Get all

        PersonGroup Update(PersonGroup personGroup);

        bool Delete(int id);
    }
}
