using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.Entities;
using Users.BLL.Interfaces;
using Users.DAL.Interfaces;

namespace Users.BLL
{
    public class UsersLogic : IUsersLogic
    {
        private readonly IUsersDAO _usersDAO;

        public UsersLogic(IUsersDAO usersDAO)
        {
            _usersDAO = usersDAO;
        }

        public void Add(User user)
        {
            //TODO
            _usersDAO.Add(user);
        }

        public void DeleteByID(int ID)
        {
            //TODO
            _usersDAO.DeleteByID(ID);
        }

        public IEnumerable<User> GetAll()
        {
            //TODO
            return _usersDAO.GetAll();
        }
    }
}
