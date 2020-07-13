using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 5, 3, 3, 1, 1};
            Console.WriteLine(arr.RepeatedElement());

            Console.ReadKey();
        }
    }
    public static class IntArrayExtensions
    {
        public static void Modify(this int[] array, Func<int, int> function)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = function(array[i]);
        }

        public static int SumOfElements(this int[] array)
        {
            int sum = 0;
            foreach (var item in array)
                sum += item;
            return sum;
        }

        public static int Average(this int[] array)
        {
            int average = 0;

            foreach (var item in array)
            {
                average += item;
            }

            return average / array.Length;
        }

        public static int RepeatedElement(this int[] array)
        {
            int element = 0;
            int maxRepetition = 0;

            Dictionary<int, int> RepetitionOfElements = new Dictionary<int, int>();

            for(int i = 0; i < array.Length; i++)
            {
                if (RepetitionOfElements.ContainsKey(array[i]))
                    RepetitionOfElements[array[i]]++;
                else
                    RepetitionOfElements.Add(array[i], 1);
            }

            for (int i = 0; i < array.Length; i++)
            {
                if(RepetitionOfElements[array[i]] > maxRepetition)
                {
                    maxRepetition = RepetitionOfElements[array[i]];
                    element = RepetitionOfElements.Keys.ElementAt(i);
                }
            }

            return element;
        }

    }
}
