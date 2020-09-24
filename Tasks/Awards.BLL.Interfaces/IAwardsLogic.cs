using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.Entities;

namespace Awards.BLL.Interfaces
{
    public interface IAwardsLogic
    {
        void Add(Award award);

        void DeleteByID(int ID);

        IEnumerable<Award> GetAll();
    }
}
