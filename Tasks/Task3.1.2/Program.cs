using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //Replace punctuation characters on space
            //Убираем все знаки пунктуации
            string[] punk_marks = { ".", ",", ";", ":", "!", "?", "...", "-", "[", "]", "{", "}", "(", ")", "\"", "<", ">", "\'" };
            for (int i = 0; i < punk_marks.Length; i++)
                input = input.Replace(punk_marks[i], " ");

            //Разбиваем строку на слова
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //Создаем коллекцию, где слова и количество их повторений
            Dictionary<string, int> numberOfRepetitions = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if(numberOfRepetitions.ContainsKey(words[i]))
                    numberOfRepetitions[words[i]]++;
                else
                    numberOfRepetitions.Add(words[i], 1);
            }
            //Выводим количество повторений для каждого слова
            for(int i = 0; i < numberOfRepetitions.Count; i++)
            {
                Console.WriteLine("Количество повторений слова \"" + numberOfRepetitions.Keys.ElementAt(i) + "\" = " + numberOfRepetitions.Values.ElementAt(i));
            }

            Console.ReadKey();
        }
    }
}
