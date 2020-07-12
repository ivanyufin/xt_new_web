using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text: ");
            string input = Console.ReadLine();
            //Replace punctuation characters on space
            ReplacePunctuation(input);
            //Splits a string into words
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //Create a collection where the words and the number of repetitions
            Dictionary<string, int> numberOfRepetitions = new Dictionary<string, int>();
            bool diversity = true;
            string MaxRepetitions = "";
            for (int i = 0; i < words.Length; i++)
            {
                if (numberOfRepetitions.ContainsKey(words[i]))
                {
                    numberOfRepetitions[words[i]]++;
                    if (PercentageOfTotal(numberOfRepetitions[words[i]], words.Length) >= 20.0f && diversity)
                    {
                        diversity = false;
                        MaxRepetitions = words[i];
                    }
                }
                else
                    numberOfRepetitions.Add(words[i], 1);
            }

            Console.WriteLine();
            if(diversity)
                Console.WriteLine("Congratulations! You are well done, the text is diverse");
            else
                Console.WriteLine("The text is not diverse. Too many repetitions of the same word, namely: " + MaxRepetitions);
            //Выводим количество повторений для каждого слова
            Console.WriteLine();
            Console.WriteLine("Number of repetitions of a word and percentage of total count words: ");
            for (int i = 0; i < numberOfRepetitions.Count; i++)
                Console.WriteLine(numberOfRepetitions.Keys.ElementAt(i) + "\" = " + numberOfRepetitions.Values.ElementAt(i) + " " + PercentageOfTotal(numberOfRepetitions.Values.ElementAt(i), words.Length).ToString("F2") + "%");

            Console.ReadKey();
        }

        static double PercentageOfTotal(int element, int count)
        {
            return (((double)element / (double)(count)) * 100);
        }

        static string ReplacePunctuation(string input)
        {
            string[] punk_marks = { ".", ",", ";", ":", "!", "?", "...", "-", "[", "]", "{", "}", "(", ")", "\"", "<", ">", "\'" };
            for (int i = 0; i < punk_marks.Length; i++)
                input = input.Replace(punk_marks[i], " ");
            return input;
        }
    }
}
