using System;

namespace Task1._1._9
{
    class Program
    {
        static void Main(string[] args)
        {
            const int length_arr = 10;
            int[] arr = new int[length_arr];
            Random r = new Random();
            Console.WriteLine("Source array: ");
            int sum = 0;
            for (int i = 0; i < length_arr; i++)
            {
                arr[i] = r.Next(-100, 100);
                if (arr[i] > 0)
                    sum += arr[i];
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n\nNon-negative sum: " + sum);
            Console.ReadKey();
        }
    }
}
