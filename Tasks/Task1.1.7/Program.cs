using System;

namespace Task1._1._7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            Random rand = new Random();
            Console.WriteLine("Source array: ");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1000);
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n\nMinimal element: " + MinimalElement(arr) + "\n");
            Console.WriteLine("Maximal element: " + MaximalElement(arr) + "\n");
            Sort(ref arr);
            Console.WriteLine("Sorted array: ");
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.ReadKey();
        }
        /// <summary>
        /// Sorts input array by bubble sort
        /// </summary>
        /// <param name="arr">input array</param>
        static void Sort(ref int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        static int MinimalElement(int[] arr)
        {
            int min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] < min)
                    min = arr[i];

            return min;
        }

        static int MaximalElement(int[] arr)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] > max)
                    max = arr[i];
            return max;
        }
    }
}
