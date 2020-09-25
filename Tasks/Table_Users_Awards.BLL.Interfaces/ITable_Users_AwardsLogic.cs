using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.Entities;

namespace Table_Users_Awards.BLL.Interfaces
{
    public interface ITable_Users_AwardsLogic
    {
        void Add(int userID, int awardID);

        IEnumerable<Award> GetAwardsByUserID(int userID);

        IEnumerable<User> GetUsersByAwardID(int awardID);

        void DeleteByAwardID(int awardID);

        void DeleteByUserID(int userID);

        void Delete(int awardID, int userID);
    }
}
