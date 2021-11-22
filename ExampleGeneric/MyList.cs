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
}
