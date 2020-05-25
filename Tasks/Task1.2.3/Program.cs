using System;

namespace Task1._2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //Replace punctuation characters on space
            string[] punk_marks = { ".", ",", ";", ":", "!", "?", "...", "-", "[", "]", "{", "}", "(", ")", "\"", "<", ">", "\'" };
            for (int i = 0; i < punk_marks.Length; i++)
                input = input.Replace(punk_marks[i], " ");

            string[] arr = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            foreach(var s in arr)
                if (s[0] >= 'a' && s[0] <= 'z' || s[0] >= 'а' && s[0] <= 'я')
                    count++;

            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}
