using System;

namespace Task1._2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first string: ");
            string str1 = Console.ReadLine();
            Console.WriteLine("\nEnter second string: ");
            string str2 = Console.ReadLine();
            //Delete all spaces
            while(str2.IndexOf(" ") != -1)
                str2 = str2.Replace(" ", "");
            string words = "";
            //Fill the "dictionary" with the letters that are in the second line (removing duplicates), 
            //while checking whether they are in the first line at all
            foreach (var c in str2)
                if (words.IndexOf(c) == -1 && str1.IndexOf(c) != -1)
                    words += c;

            //iterate over the dictionary while it has elements
            while(words.Length > 0)
            {
                if (str1.IndexOf(words[0]) != -1)
                {
                    string current_word = words[0].ToString();//for readability
                    str1 = str1.Replace(current_word, current_word + current_word);//replacing the symbol with a doubled one
                    words = words.Remove(0, 1);
                }
            }

            Console.WriteLine("\nOutput: " + str1);
            Console.ReadKey();
        }
    }
}
