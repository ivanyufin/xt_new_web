using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table_Users_Awards.BLL.Interfaces;
using Table_Users_Awards.DAL.Interfaces;
using Task7._1._1.Entities;

namespace Table_Users_Awards.BLL
{
    public class Table_Users_AwardsLogic : ITable_Users_AwardsLogic
    {
        private readonly ITable_Users_AwardsDAO _table_Users_AwardsDAO;

        public Table_Users_AwardsLogic(ITable_Users_AwardsDAO table_Users_AwardsDAO)
        {
            _table_Users_AwardsDAO = table_Users_AwardsDAO;
        }

        public void Add(int userID, int awardID)
        {
            _table_Users_AwardsDAO.Add(userID, awardID);
            //TODO
        }

        public void Delete(int awardID, int userID)
        {
            _table_Users_AwardsDAO.Delete(awardID, userID);
        }

        public void DeleteByAwardID(int awardID)
        {
            _table_Users_AwardsDAO.DeleteByAwardID(awardID);
            //TODO
        }

        public void DeleteByUserID(int userID)
        {
            _table_Users_AwardsDAO.DeleteByUserID(userID);
            //TODO
        }

        public IEnumerable<Award> GetAwardsByUserID(int userID)
        {
            return _table_Users_AwardsDAO.GetAwardsByUserID(userID);
        }

        public IEnumerable<User> GetUsersByAwardID(int awardID)
        {
            return _table_Users_AwardsDAO.GetUsersByAwardID(awardID);
        }
    }
}
