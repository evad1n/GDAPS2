using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The original list values: ");
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.Add(1);
            list.Add(3);
            list.Add(6);
            list.Add(72);
            list.Add(123123);
            list.Add(322);

            for (int i = 0; i < list.count; i++)
            {
                Console.WriteLine(list.GetData(i));
            }

            Console.WriteLine("\nAttempting to remove an invalid index: ");
            try
            {
                Console.WriteLine(list.Remove(10));
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\nRemoved list values: ");
            Console.WriteLine(list.Remove(0));
            Console.WriteLine(list.Remove(list.count-1));
            Console.WriteLine(list.Remove(2));

            Console.WriteLine("\nThe changed list values: ");
            for (int i = 0; i < list.count; i++)
            {
                Console.WriteLine(list.GetData(i));
            }
        }
    }
}
