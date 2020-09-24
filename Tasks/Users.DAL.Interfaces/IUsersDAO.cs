using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.Entities;

namespace Users.DAL.Interfaces
{
    public interface IUsersDAO
    {
        void Add(User user);

        void DeleteByID(int ID);

        IEnumerable<User> GetAll();
    }
}
