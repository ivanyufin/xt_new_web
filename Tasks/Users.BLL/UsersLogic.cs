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
            _usersDAO.Add(user);
        }

        public void DeleteByID(int ID)
        {
            _usersDAO.DeleteByID(ID);
        }

        public IEnumerable<User> GetAll()
        {
            return _usersDAO.GetAll();
        }

        public int GetID(string name)
        {
            return _usersDAO.GetID(name);
        }

        public User GetUserByID(int ID)
        {
            return _usersDAO.GetUserByID(ID);
        }

        public void Update(User user, string newName, DateTime newDateOfBirth)
        {
            _usersDAO.Update(user, newName, newDateOfBirth);
        }
    }
}
