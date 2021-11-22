using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _indexers
{
    class Dictionary
    {
        private string[] value = new string[7];
        private int[] keyInt = new int[7];
        private string[] keyString = new string[7];

        public Dictionary()
        {
            value[0] = "Monday";    keyString[0] = "Երկուշաբթի";    keyInt[0] = 1;
            value[1] = "Tuesday";   keyString[1] = "Երեքշաբթի";     keyInt[1] = 2;
            value[2] = "Wednesday"; keyString[2] = "Չորեքշաբթի";    keyInt[2] = 3;
            value[3] = "Thursday";  keyString[3] = "Հինգշաբթի";     keyInt[3] = 4;
            value[4] = "Friday";    keyString[4] = "Ուրբաթ";        keyInt[4] = 5;
            value[5] = "Saturday";  keyString[5] = "Շաբաթ";         keyInt[5] = 6;
            value[6] = "Sunday";    keyString[6] = "Կիրակի";        keyInt[6] = 7;
        }

        public string this[string index]
        {
            get 
            {
                for (int i = 0; i < keyString.Length; i++)
                    if (keyString[i] == index)
                        return  value[i] + new string('-', 10) + keyString[i];
                return null;
            }
        }

        public string this[int index]
        {
            get
            {
                for (int i = 0; i < keyInt.Length; i++)
                    if (keyInt[i] == index)
                        return keyInt[i] + "\t" + value[i];
                return null;
            }
        }

        static void Main(string[] args)
        {
            Dictionary dictionary = new Dictionary();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(dictionary["Երկուշաբթի"]);
            Console.WriteLine(dictionary["Երեքշաբթի"]);
            Console.WriteLine(dictionary["Չորեքշաբթի"]);
            Console.WriteLine(dictionary["Հինգշաբթի"]);
            Console.WriteLine(dictionary["Ուրբաթ"]);
            Console.WriteLine(dictionary["Շաբաթ"]);
            Console.WriteLine(dictionary["Կիրակի"]);
            
            for (int i = 1; i < dictionary.keyInt.Length + 1; i++)
            {
                Console.WriteLine(dictionary[i]);
            }

            Console.ReadKey();
        }
    }
}
