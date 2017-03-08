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
            //If there are no elements in the list
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
            if(index < 0)
            {
                throw new Exception("That is an invalid index.");
            }
            CustomNode<T> newData = new CustomNode<T>(data);
            CustomNode<T> temp;
            //If this is the head
            if (index == 0)
            {
                Add(data);
            }
            //If this is the tail
            else if (index >= (count - 1))
            {
                temp = tail;
                tail.next = newData;
                tail = newData;
                newData.previous = temp;
                count++;
            }
            else
            {
                temp = head;
                for (int i = 1; i <= index; i++)
                {
                    temp = temp.next;
                }
                temp.previous.next = newData;
                newData.next = temp;
                newData.previous = temp.previous;
                temp.previous = newData;
                count++;
            }
        }

        public T Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new Exception("That is an invalid index.");
            }
            CustomNode<T> temp;
            //If this is the head
            if (index == 0)
            {
                if (count > 1)
                {
                    temp = head;
                    head = head.next;
                    head.previous = null;
                }
                else
                {
                    temp = head;
                    head = null;
                }
            }
            //If this is the tail
            else if (index == (count - 1))
            {
                temp = tail;
                tail = tail.previous;
                tail.next = null;
            }
            else
            {
                temp = head;
                for (int i = 1; i <= index; i++)
                {
                    temp = temp.next;
                }
                //Fill in the gap
                temp.previous.next = temp.next;
                temp.next.previous = temp.previous;
            }
            count--;
            return temp.Data;
        }

        public T GetData(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new Exception("That is an invalid index.");
            }
            CustomNode<T> temp;
            temp = head;
            for(int i = 1; i <= index; i++)
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

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(GetData(i).ToString());
            }
        }
    }
}
