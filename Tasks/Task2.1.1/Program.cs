using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task2._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arr = new char[] { 'H','e','l','l','o',' ','w','o','r','l','d' };
            CrazyString crazyString = new CrazyString(arr);
            Console.WriteLine(crazyString);
            Console.ReadKey();
        }
    }
    class CrazyString
    {
        /// <summary>
        /// Главный массив символов, представляющий этот класс
        /// </summary>
        protected char[] mainArray;
        private int length;
        public int Length
        {
            get
            {
                return length;
            }
        }
        public CrazyString(char[] array)
        {
            mainArray = array;
            length = array.Length;
        }

        /// <summary>
        /// Посимвольное сравнение
        /// </summary>
        /// <param name="crazyString"></param>
        /// <returns></returns>
        public bool Equals(CrazyString crazyString)
        {
            //Сделать через расчет хэша, так быстрее будет работать
            if (mainArray.Length != crazyString.mainArray.Length)
                return false;
            for(int i = 0; i < mainArray.Length; i++)
            {
                if (mainArray[i] != crazyString.mainArray[i])
                    return false;
            }
            return true;
        }

        public CrazyString Concat(CrazyString crazyString)
        {
            char[] returnedArray = new char[mainArray.Length + crazyString.mainArray.Length];
            for (int i = 0; i < mainArray.Length; i++)
                returnedArray[i] = mainArray[i];
            for (int i = mainArray.Length, j = 0; i < returnedArray.Length; i++, j++)
                returnedArray[i] = crazyString.mainArray[j];
            CrazyString returnedString = new CrazyString(returnedArray);
            return returnedString;
        }

        public char this[int index]
        {
            get
            {
                return mainArray[index];
            }
            set
            {
                mainArray[index] = value;
            }
        }

        public override string ToString()
        {
            string returnedString = "";
            for (int i = 0; i < mainArray.Length; i++)
                returnedString += mainArray[i];
            return returnedString;
        }

        public int IndexOf(char key)
        {
            for (int i = 0; i < mainArray.Length; i++)
                if (mainArray[i] == key)
                    return i;

            return -1;
        }

        public int LastIndexOf(char key)
        {
            for (int i = mainArray.Length - 1; i >= 0; i--)
                if (mainArray[i] == key)
                    return i;

            return -1;
        }

        public char[] ConvertToChar()
        {
            return mainArray;
        }

        public CrazyString ConvertFromChar(char[] array)
        {
            return new CrazyString(array);
        }

        public static CrazyString operator +(CrazyString left, CrazyString right)
        {
            return left.Concat(right);
        }

        public static CrazyString operator +(CrazyString left, char right)
        {
            char[] concatedArray = new char[left.Length + 1];
            for (int i = 0; i < left.Length; i++)
                concatedArray[i] = left[i];
            concatedArray[concatedArray.Length - 1] = right;
            return new CrazyString(concatedArray);
        }

        #region Функции, которых нет в стандартном функционале
        public int[] ToInt32()
        {
            int[] returnedArray = new int[mainArray.Length];
            for(int i = 0; i < mainArray.Length; i++)
            {
                if(mainArray[i] >= '0' && mainArray[i] <= '9')
                {
                    returnedArray[i] = mainArray[i] - '0';
                }
                else
                {
                    throw new ArgumentException("mainArray", "Массив не может содержать ничего, кроме цифр");
                }
            }
            return returnedArray;
        }

        private string GetHash(char[] array)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(array));

            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Сравнение по хэшу
        /// </summary>
        /// По-идее должно работать быстрее
        /// <param name="crazyString"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool Equals(CrazyString crazyString, bool hash)
        {
            string firstHash = GetHash(mainArray);
            string secondHash = GetHash(crazyString.ConvertToChar());
            if (firstHash == secondHash)
                return true;
            return false;
        }
        #endregion
    }
}
