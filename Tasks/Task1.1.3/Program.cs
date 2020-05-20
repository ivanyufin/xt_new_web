using System;

namespace Task1._1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int length = 1;//this is length of last line
            for (int i = 1; i < n; i++)//calculate it
                length += 2;
            string[] star_lines = new string[n];
            star_lines[n - 1] = new string('*', length);//filling last line asterisks
            int indent = 1;//this is the indent left and right in star line


            //
            //filling star lines goes from the end to indent left and right
            //with each iteration, the indentation left and right increases
            //for example...                                                           |--this is--|
            //                                                                         |   indent  |
            //                                                imagine indent as "i"    |           |
            //                                  *                                      |-> ii*ii <-|        
            //n = 3. We have to get =>         ***                                     |-> i***i <-|
            //                                *****                                        *****<--this is length
            //
            //it turns out that new line filline for the next formula: indent + (length - indent * 2) + indent
            for (int i = n - 2; i >= 0; i--)
            {
                star_lines[i] = new string(' ', indent) + new string('*', (length - indent * 2)) + new string(' ', indent);
                indent++;
            }
            for (int i = 0; i < n; i++)
                Console.WriteLine(star_lines[i]);
            Console.ReadKey();
        }
    }
}
