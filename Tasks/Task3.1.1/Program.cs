using System;
using System.Collections.Generic;

namespace Task3._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            Console.WriteLine("Введите N:");
            int.TryParse(Console.ReadLine(), out n);
            while (n == 0)
            {
                Console.WriteLine("Вы ввели некорректное значение N, попробуйте еще раз");
                Console.WriteLine("Введите N:");
                int.TryParse(Console.ReadLine(), out n);
            }

            List<int> people = new List<int>(n);
            for (int i = 0; i < people.Capacity; i++)
                people.Add(i);

            int deletingPeople = 0;
            Console.WriteLine("Введите, какой по счету человек будет вычеркнут каждый раунд:");
            int.TryParse(Console.ReadLine(), out deletingPeople);
            while (deletingPeople == 0 || deletingPeople < 0 || deletingPeople > people.Count)
            {
                Console.WriteLine("Вы ввели некорректное значение. Оно не может быть меньше либо равно 0 или больше N");
                Console.WriteLine("Введите, какой по счету человек будет вычеркнут каждый раунд:");
                int.TryParse(Console.ReadLine(), out deletingPeople);
            }

            Console.WriteLine("Сгенерирован круг людей. Начинаем вычеркивать каждого " + deletingPeople.ToString());
            int j = 1;

            while(people.Count >= deletingPeople)
            {
                if (people.Count > deletingPeople)
                    people.RemoveAt(deletingPeople);
                else
                    people.RemoveAt(people.Count - 1);

                Console.WriteLine("Раунд " + j + ". Вычеркнут человек. Людей осталось: " + people.Count);
                j++;
            }

            Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей.");
            Console.ReadKey();
        }
    }
}
