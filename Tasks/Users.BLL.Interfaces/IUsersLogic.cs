using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.Entities;

namespace Users.BLL.Interfaces
{
    public interface IUsersLogic
    {
        void Add(User user);

        void DeleteByID(int ID);

        IEnumerable<User> GetAll();
    }
}
