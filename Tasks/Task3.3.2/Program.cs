using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._3._2
{
    public enum Languages
    {
        None,
        Russian,
        English,
        Number,
        Mixed
    }

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the text: ");
            string inputText = Console.ReadLine();

            Console.WriteLine(inputText.HowLanguage());

            Console.ReadKey();
        }
    }

    public static class StringExtensions
    {
        public static Languages HowLanguage(this string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
                return Languages.None;

            Languages language = Languages.None;

            inputString = inputString.ToLower();
            //I didn't want to use collections, I decided to show that this can also be solved

            bool[] languages = new bool[4];//Russian, English, Number, Mixed
            //                                 |        |        |       |
            //languages =                   {false,   false,   false,  false}

            foreach (var item in inputString)
            {
                if (item >= 'а' && item <= 'я')
                    languages[0] = true;//  {true,    false,   false,  false}
                else if (item >= 'a' && item <= 'z')
                    languages[1] = true;//  {false,   true,    false,  false}
                else if (item >= '0' && item <= '9')
                    languages[2] = true;//  {false,   false,   true,   false}
                else
                    languages[3] = true;//  {false,   false,   false,   true}
            }

            if (languages[3])
            {
                language = Languages.Mixed;
                return language;
            }
            else if (languages[0] && !languages[1] && !languages[2] && !languages[3])
            {
                language = Languages.Russian;
                return language;
            }
            else if (!languages[0] && languages[1] && !languages[2] && !languages[3])
            {
                language = Languages.English;
                return language;
            }
            else if (!languages[0] && !languages[1] && languages[2] && !languages[3])
            {
                language = Languages.Number;
                return language;
            }
            else language = Languages.Mixed;

            return language;
        }
    }
}
