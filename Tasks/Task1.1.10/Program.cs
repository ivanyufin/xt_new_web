using System;

namespace Task1._1._10
{
    class Program
    {
        static void Main(string[] args)
        {
            const int length_arr = 3;
            int[,] arr = new int[length_arr, length_arr];
            Random r = new Random();
            Console.WriteLine("Source array: ");
            int sum = 0;
            for (int i = 0; i < length_arr; i++)
            {
                for (int j = 0; j < length_arr; j++)
                {
                    arr[i, j] = r.Next(100);
                    Console.Write(arr[i, j] + " ");
                    if ((i + j + 2) % 2 == 0)
                        sum += arr[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine("Sum: " + sum);
            Console.ReadKey();
        }
    }
}
