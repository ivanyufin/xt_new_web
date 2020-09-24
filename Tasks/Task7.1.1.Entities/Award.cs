using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7._1._1.Entities
{
    public class Award
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public Award(int id)
        {
            this.ID = id;
        }
    }
}
