using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomQueue
{
    class GameQueue : IQueue
    {
        string[] list;

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public bool IsEmpty
        {
            get { return count == 0; }
        }

        public GameQueue(int size)
        {
            list = new string[size];
        }

        public void Enqueue(string str)
        {
            if(count == list.Length)
            {
                throw new IndexOutOfRangeException("The queue is full");
            }
            else
            {
                list[count] = str;
                count++;
            }
        }

        public string Dequeue()
        {
            if(count > 0)
            {
                string temp = list[0];
                list = list.Skip(1).ToArray();
                count--;
                return temp;
            }
            else
            {
                return null;
            }

        }

        public string Peek()
        {
            return list[0];
        }
    }
}
