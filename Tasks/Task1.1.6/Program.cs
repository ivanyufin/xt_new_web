using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._1._6
{
    class Program
    {
        [Flags]
        enum Font : byte
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }
        static void Main(string[] args)
        {
            Font font = Font.None;
            while (true)
            {
                Console.WriteLine("Label options: " + font);
                Console.WriteLine("Enter: ");
                Console.WriteLine("     1: bold");
                Console.WriteLine("     2: italic");
                Console.WriteLine("     3: underline");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        font ^= Font.Bold;
                        break;
                    case 2:
                        font ^= Font.Italic;
                        break;
                    case 3:
                        font ^= Font.Underline;
                        break;
                }
            }
        }
    }
}
