using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.Entities;

namespace Task7._1._1.DAL.Interfaces
{
    public interface ITask7DAO
    {
        void AddUser(User user);

        void DeleteUser(User user);

        IEnumerable<User> GetAllUsers();

        void AddAward(Award award);

        void DeleteAward(Award award);

        IEnumerable<Award> GetAllAwards();
    }
}
