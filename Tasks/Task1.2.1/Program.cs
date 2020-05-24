using System;

namespace Task1._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Source string: ");
            string s = Console.ReadLine();
            //Delete punctuation characters
            string[] punk_marks = { ".", ",", ";", ":", "!", "?", "...", "-", "[", "]", "{", "}", "(", ")", "\"", "<", ">", "\'" };
            for (int i = 0; i < punk_marks.Length; i++)
                s = s.Replace(punk_marks[i], "");
            //Dividing a string into an array of words
            string[] arr = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;
            foreach(var str in arr)
                sum += str.Length;
            float average = (float)sum / (float)arr.Length;
            //The total is not rounded
            Console.WriteLine("Average word length(not rounded): " + average);
            Console.ReadKey();
        }
    }
}
