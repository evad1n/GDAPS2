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

            for(int i = 0; i < 5; i++)
            {
                list.GetData(i);
            }
        }
    }
}
