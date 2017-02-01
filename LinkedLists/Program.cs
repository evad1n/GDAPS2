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
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.Add(1);
            list.Add(3);
            list.Add(6);
            list.Add(72);
            list.Add(123123);
            list.Add(322);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(list.GetData(i));
            }

            try
            {
                list.Remove(10);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            list.Remove(0);
            list.Remove(4);
            list.Remove(2);

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(list.GetData(i));
            }
        }
    }
}
