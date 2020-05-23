using System;

namespace Task1._1._8
{
    class Program
    {
        static void Main(string[] args)
        {
            const int length_arr = 4;
            int[,,] arr = new int[length_arr, length_arr, length_arr];
            Random r = new Random();
            for(int i = 0; i < length_arr; i++)
                for(int j = 0; j < length_arr; j++)
                    for (int k = 0; k < length_arr; k++)
                        arr[i, j, k] = r.Next(-100, 100);
            for (int i = 0; i < length_arr; i++)
                for (int j = 0; j < length_arr; j++)
                    for (int k = 0; k < length_arr; k++)
                        if (arr[i, j, k] > 0)
                            arr[i, j, k] = 0;
            Console.ReadKey();
        }
    }
}
