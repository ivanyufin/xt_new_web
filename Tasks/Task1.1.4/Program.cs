using System;

namespace Task1._1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            //same generation as in task 1.1.3 but in the cycle and centered according
            Console.WriteLine("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int length = 1;
                for (int j = 1; j < i; j++)
                    length += 2;
                string[] star_lines = new string[n];
                star_lines[i - 1] = new string('*', length);
                int indent = 1;
                for (int j = i - 2; j >= 0; j--)
                {
                    star_lines[j] = new string(' ', indent) + new string('*', (length - indent * 2)) + new string(' ', indent);
                    indent++;
                }
                for (int j = 0; j < i; j++)
                    Console.WriteLine(new string(' ', n - i) + star_lines[j]);//output and centering by adding indentation on the left
            }
            Console.ReadKey();
        }
    }
}
