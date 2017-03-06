using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedLists
{
    class CustomLinkedList<T>
    {
        CustomNode<T> head;
        CustomNode<T> tail;

        int count;

        public int Count { get { return count; } }

        public void Add(T data)
        {
            if (count == 0)
            {
                CustomNode<T> temp = new CustomNode<T>(data);
                head = temp;
                tail = temp;
                count++;
            }
            else
            {
                CustomNode<T> temp = new CustomNode<T>(data);
                tail.next = temp;
                temp.previous = tail;
                tail = tail.next;
                count++;
            }
        }

        public void Insert(T data, int index)
        {

        }

        public T Remove(int index)
        {
            CustomNode<T> temp;
            temp = head;
            for (int i = 1; i < index; i++)
            {
                temp = temp.next;
            }
            //fill in gap
            return temp.Data;
        }

        public T GetData(int index)
        {
            CustomNode<T> temp;
            temp = head;
            for(int i = 1; i < index; i++)
            {
                temp = temp.next;
            }
            return temp.Data;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
    }
}
