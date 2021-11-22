using System;

//ITVDN HomeWork C# Essential Lesson 10
namespace Generic
{
    public interface IMyList<T>
    {
        void Add(T element);

        T this[int index] { get; }

        int Count { get; }

        void Clear();

        bool Contains(T item);
    }

    public class MyList<T> : IMyList<T>
    {
        private T[] array;

        public MyList()
        {
            array = new T[0];
        }

        public void Add(T element)
        {
            T[] tempArray = new T[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            tempArray[array.Length] = element;
            array = tempArray;
        }

        public T this[int index]
        {
            get
            {
                return array[index];
            }
        }

        public int Count
        {
            get
            {
                return array.Length;
            }
        }

        public void Clear()
        {
            array = new T[0];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array.GetType().GetElementType() == typeof(int))
                {
                    if ((int)(object)array[i] == (int)(object)item)
                    {
                        return true;
                    }
                }
                else if (array.GetType().GetElementType() == typeof(String))
                {
                    if ((string)(object)array[i] == (string)(object)item)
                    {
                        return true;
                    }
                }
                else
                {
                    throw new Exception("TypeMismatchException");
                }
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input an int array length: ");
            string str = Console.ReadLine();
            int length = default(int);
            if (!string.IsNullOrEmpty(str))
            {
                length = int.Parse(str);
            }

            var list = new MyList<int>();
            var rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                list.Add(rnd.Next(100));
            }

            Console.WriteLine("Elements are:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 20));

            Console.Write("Input item for search: ");
            if (list.Contains(int.Parse(Console.ReadLine())))
            {
                Console.WriteLine("The searched element is present in the list");
            }
            else
            {
                Console.WriteLine("The searched element is not present in the list");
            }

            Console.Write("Input a string array length: ");
            str = Console.ReadLine();
            length = default(int);
            if (!string.IsNullOrEmpty(str))
            {
                length = int.Parse(str);
            }

            var listStr = new MyList<string>();
            for (int i = 0; i < length; i++)
            {
                Console.Write("Input string: ");
                listStr.Add(Console.ReadLine());
            }

            Console.WriteLine("Elements are:");
            for (int i = 0; i < listStr.Count; i++)
            {
                Console.Write($"{listStr[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 20));

            Console.Write("Input item for search: ");
            if (listStr.Contains(Console.ReadLine()))
            {
                Console.WriteLine("The searched element is present in the list");
            }
            else
            {
                Console.WriteLine("The searched element is not present in the list");
            }

            Console.ReadKey();
        }
    }
}
