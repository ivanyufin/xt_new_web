using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //This task may be solved different variants
            Console.WriteLine("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            //Variant 1: using a nested loop
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
            //or
            //Variant 2: using the creation a new line and filling it with asterisks
            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine(new string('*', i));
            }
            Console.ReadKey();
        }
    }
}
