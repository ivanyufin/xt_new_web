using System;

namespace Task1._2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input string: ");
            string input = Console.ReadLine();

            if (input[0] >= 'a' && input[0] <= 'z' || input[0] >= 'а' && input[0] <= 'я')
            {
                UpperLetter(ref input, 0);
            }
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == '.' || input[i] == '!' || input[i] == '?')
                    for(int j = i; j < input.Length; j++)
                        if(input[j] >= 'a' && input[j] <= 'z' || input[j] >= 'а' && input[j] <= 'я')
                        {
                            UpperLetter(ref input, j);
                            break;
                        }
            }

            Console.WriteLine(input);
            Console.ReadKey();
        }

        static void UpperLetter(ref string str, int index)
        {
            string letter = str[index].ToString().ToUpper();
            str = str.Remove(index, 1);
            str = str.Insert(index, letter);
        }
    }
}
