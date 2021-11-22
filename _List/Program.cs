using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ListImplementation
{
    class Program
    {
        static void Main()
        {
            _List myList = new _List();
            myList.Add(11);
            myList.Add(22);
            myList.Add(33);
            myList.Add(44);
            myList.Add(55);
            myList.Add(66);
            myList.Add(77);
            myList.Add(88);
            myList.Add(99);

            foreach (int item in myList)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine("Our list");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write($"{myList[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            int number = 222;
            if (!myList.Contains(number))
            {
                myList.Add(number);
            }
            Console.WriteLine($"The added value is {number}");
            Console.WriteLine("\n" + new string('-', 20));

            myList[9] = 111;


            int[] array = new int[12];
            myList.CopyTo(3, array, 0, 7);
            Console.WriteLine($"Array elements is: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            number = myList.IndexOf(22);
            Console.WriteLine($"The index of the first occurrence of a given value is {number}");

            number = myList.IndexOf(33, 1);
            Console.WriteLine($"The index of the first occurrence of a given value starting at the given index is {number}");

            number = myList.IndexOf(111, 1, 8);
            Console.WriteLine($"The index of the first occurrence of a given value starting at the given index and up to count the number of given elements is {number}");

            myList.Remove(11);
            Console.WriteLine("After Remove");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write($"{myList[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            myList.Insert(0, 11);
            Console.WriteLine("After Insert");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write($"{myList[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            int removingElement = myList[3];
            myList.RemoveAt(3);
            Console.WriteLine($"We are removed the element {removingElement}");
            Console.WriteLine("After RemoveAt");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write($"{myList[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            myList.RemoveRange(0, 2);
            Console.WriteLine("After RemoveRange");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write($"{myList[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            myList.Clear();
            Console.WriteLine($"After Clear we have {myList.Count} elements");

            Console.ReadKey();
        }
    }
}
