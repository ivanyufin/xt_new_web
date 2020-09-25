using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Awards.BLL.Interfaces;
using Awards.DAL.Interfaces;
using Task7._1._1.Entities;

namespace Awards.BLL
{
    public class AwardsLogic : IAwardsLogic
    {
        private readonly IAwardsDAO _awardsDAO;

        public AwardsLogic(IAwardsDAO awardsDAO)
        {
            _awardsDAO = awardsDAO;
        }

        public void Add(Award award)
        {
            _awardsDAO.Add(award);
        }

        public void DeleteByID(int ID)
        {
            _awardsDAO.DeleteByID(ID);
        }

        public IEnumerable<Award> GetAll()
        {
            return _awardsDAO.GetAll();
        }

        public Award GetAwardByID(int ID)
        {
            return _awardsDAO.GetAwardByID(ID);
        }

        public int GetID(string title)
        {
            return _awardsDAO.GetID(title);
        }

        public void Update(Award user, string newTitle)
        {
            _awardsDAO.Update(user, newTitle);
        }
    }
}
