using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Awards.BLL;
using Awards.BLL.Interfaces;
using Awards.DAL;
using Awards.DAL.Interfaces;
using Table_Users_Awards.BLL;
using Table_Users_Awards.BLL.Interfaces;
using Table_Users_Awards.DAL;
using Table_Users_Awards.DAL.Interfaces;
using Users.BLL;
using Users.BLL.Interfaces;
using Users.DAL;
using Users.DAL.Interfaces;

namespace Task7._1._1.Common
{
    public static class DependencyResolver
    {
        private static readonly IUsersLogic _usersLogic;
        private static readonly IUsersDAO _usersDAO;
        private static readonly IAwardsLogic _awardsLogic;
        private static readonly IAwardsDAO _awardsDAO;
        private static readonly ITable_Users_AwardsLogic _table_Users_AwardsLogic;
        private static readonly ITable_Users_AwardsDAO _table_Users_AwardsDAO;

        public static IUsersLogic UsersLogic => _usersLogic;
        public static IUsersDAO UsersDAO => _usersDAO;
        public static IAwardsLogic AwardsLogic => _awardsLogic;
        public static IAwardsDAO AwardsDAO => _awardsDAO;
        public static ITable_Users_AwardsLogic Table_Users_AwardsLogic => _table_Users_AwardsLogic;
        public static ITable_Users_AwardsDAO Table_Users_AwardsDAO => _table_Users_AwardsDAO;

        static DependencyResolver()
        {
            _usersDAO = new JsonUsersDAO();
            _usersLogic = new UsersLogic(_usersDAO);
            _awardsDAO = new JsonAwardsDAO();
            _awardsLogic = new AwardsLogic(_awardsDAO);
            _table_Users_AwardsDAO = new JsonTable_Users_AwardsDAO();
            _table_Users_AwardsLogic = new Table_Users_AwardsLogic(_table_Users_AwardsDAO);
        }
    }
}
