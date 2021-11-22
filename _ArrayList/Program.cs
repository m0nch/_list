using System;
using System.Collections;
using System.Collections.Generic;

namespace _ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            _ArrayList _arrayList = new _ArrayList();
            List<string> list = new List<string>() { "London", "New York", "Moscow", "Tokio", "Yerevan"}; 

            _arrayList.Add(11);
            _arrayList.Add(22);
            _arrayList.Add(33);
            _arrayList.Add(44);
            _arrayList.Add(55);
            _arrayList.Add(list); //???
            _arrayList.Add("Hello ");
            _arrayList.Add("World");
            _arrayList.Add("!");

            foreach (var item in _arrayList)
            {
                Console.Write($"{item.ToString()} ");
            }
            Console.WriteLine();

            Console.WriteLine("Our list");
            for (int i = 0; i < _arrayList.Count; i++)
            {
                Console.Write($"{_arrayList[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            int number = 222;
            if (!_arrayList.Contains(number))
            {
                _arrayList.Add(number);
            }
            Console.WriteLine($"The added value is {number}");
            Console.WriteLine("\n" + new string('-', 20));

            _arrayList[9] = "My name is John Doe";            

            number = _arrayList.IndexOf(22);
            Console.WriteLine($"The index of the first occurrence of a given value is {number}");

            number = _arrayList.IndexOf(33, 1);
            Console.WriteLine($"The index of the first occurrence of a given value starting at the given index is {number}");

            number = _arrayList.IndexOf(111, 1, 8);
            Console.WriteLine($"The index of the first occurrence of a given value starting at the given index and up to count the number of given elements is {number}");

            _arrayList.Remove(11);
            Console.WriteLine("After Remove");
            for (int i = 0; i < _arrayList.Count; i++)
            {
                Console.Write($"{_arrayList[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            _arrayList.Insert(0, 11);
            Console.WriteLine("After Insert");
            for (int i = 0; i < _arrayList.Count; i++)
            {
                Console.Write($"{_arrayList[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            int removingElement = (int)_arrayList[3];
            _arrayList.RemoveAt(3);
            Console.WriteLine($"We are removed the element {removingElement}");
            Console.WriteLine("After RemoveAt");
            for (int i = 0; i < _arrayList.Count; i++)
            {
                Console.Write($"{_arrayList[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            _arrayList.RemoveRange(0, 2);
            Console.WriteLine("After RemoveRange");
            for (int i = 0; i < _arrayList.Count; i++)
            {
                Console.Write($"{_arrayList[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            _arrayList.Clear();
            Console.WriteLine($"After Clear we have {_arrayList.Count} elements");

            Console.ReadKey();

        }
    }
}
