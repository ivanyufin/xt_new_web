using System;

namespace Task111
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter sides a и b:");
            string entered_line = Console.ReadLine();
            string[] entered_numbers = entered_line.Split(' ');
            try
            {
                int a = Convert.ToInt32(entered_numbers[0]);
                int b = Convert.ToInt32(entered_numbers[1]);
                if (a > 0 && a <= 9 && b > 0 && b <= 9)
                    Console.WriteLine("Rectangle area with sides a and b = " + (a * b));
                else
                    Console.WriteLine("You entered incorrect values");
            }
            catch { }
            Console.ReadKey();
        }
    }
}
