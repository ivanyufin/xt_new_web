using System;
using Task7._1._1.Common;
using Task7._1._1.Entities;

namespace ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            var usersLogic = DependencyResolver.UsersLogic;
            var awardsLogic = DependencyResolver.AwardsLogic;
            var tableLogic = DependencyResolver.Table_Users_AwardsLogic;

            foreach(var user in tableLogic.GetUsersByAwardID(1))
            {
                Console.WriteLine(user.Name);
            }
            Console.ReadLine();
        }
    }
}
