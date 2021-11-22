using System;

//ITVDN HomeWork C# Essential Lesson 10
namespace Generic
{
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
