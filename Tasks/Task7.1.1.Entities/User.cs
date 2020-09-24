using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7._1._1.Entities
{
    public class User
    {
        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }

        public User(int id)
        {
            this.ID = id;
        }

        public override string ToString()
        {
            return "Age: " + Age + Environment.NewLine + "DateOfBitrh: " + DateOfBirth + Environment.NewLine + "ID: " + ID + Environment.NewLine + "Name: " + Name;
        }
    }
}
