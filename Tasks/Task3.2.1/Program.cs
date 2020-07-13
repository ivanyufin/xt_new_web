using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> array = new DynamicArray<int>();
            for (int i = 0; i < 8; i++)
                array.Add(i);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }

    class DynamicArray<T> : IEnumerable<T>
    {
        private T[] array;

        public DynamicArray()
        {
            array = new T[8];
            capacity = 8;
        }

        public DynamicArray(int capacity)
        {
            array = new T[capacity];
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            array = collection.ToArray();
        }

        public void Add(T item)
        {
            if (length < capacity)
            {
                array[length] = item;
                length++;
            }
            else
            {
                capacity = capacity * 2;
                T[] newArray = new T[capacity];
                for (int i = 0; i < array.Length; i++)
                    newArray[i] = array[i];
                newArray[length] = item;
                length++;
                array = newArray;
            }
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if(length + collection.Count() >= capacity)
            {
                while(length + collection.Count() >= capacity)
                    capacity = capacity * 2;
                T[] newArray = new T[capacity];
                for (int i = 0; i < array.Length; i++)
                    newArray[i] = array[i];
                for (int i = 0; i < collection.Count(); i++)
                    newArray[i + length] = collection.ElementAt(i);
                length += collection.Count();
                array = newArray;
            }
            else
            {
                T[] newArray = new T[capacity];
                for (int i = 0; i < array.Length; i++)
                    newArray[i] = array[i];
                for (int i = 0; i < collection.Count(); i++)
                    newArray[i + length] = collection.ElementAt(i);
                length += collection.Count();
                array = newArray;
            }
        }

        public bool Remove(T item)
        {
            bool removed = false;

            T[] newArray = new T[capacity];
            int j = 0;
            for (int i = 0; i < length; i++)
                if (!array[j].Equals(item))
                {
                    newArray[i] = array[j];
                    j++;
                }
                else
                {
                    if (j + 1 < length)
                    {
                        j++;
                        newArray[i] = array[j];
                    }
                    else
                        newArray[i] = default(T);
                    length--;
                    removed = true;
                }
            array = newArray;
            return removed;
        }

        private int length;
        public int Length
        {
            get
            {
                return length;
            }
        }

        private int capacity;
        public int Capacity
        {
            get
            {
                return capacity;
            }
        }

        public bool Insert(T item, int index)
        {
            bool inserted = false;

            if (index < 0 || index >= capacity)
                throw new ArgumentOutOfRangeException();

            T[] newArray = new T[capacity + 1];
            int j = 0;
            for (int i = 0; i < length; i++)
                if (i != index)
                {
                    newArray[i] = array[j];
                    j++;
                }
                else
                {
                    if (length >= capacity)
                        capacity = capacity * 2;
                    newArray[i] = item;
                    inserted = true;
                    length++;
                }

            array = newArray;
            return inserted;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= capacity)
                    throw new ArgumentOutOfRangeException();
                return array[index];
            }
            set
            {
                if (index < 0 || index >= capacity)
                    throw new ArgumentOutOfRangeException();
                array[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < length; i++)
                yield return array[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
        }
    }
}
