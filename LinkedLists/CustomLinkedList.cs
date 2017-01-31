using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class CustomLinkedList<T>
    {
        public CustomLinkedNode<T> MyProperty { get; set; }

        public int count { get; set; }

        public CustomLinkedNode<T> head { get; set; }

        public CustomLinkedNode<T> current { get; set; }

        public CustomLinkedList()
        {
            count = 0;
        }

        public void Add(T data)
        {
            CustomLinkedNode<T> newNode = new CustomLinkedNode<T>() { Data = data };
            if (head == null)
            {
                head = newNode;
                current = head;
                count = 1;
            }
            else
            {
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
                count++;
            }
        }

        public T GetData(int index)
        {
            var current = head;
            if(index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("That index is not in the list");
            }
            else
            {
                for(int i = 0; i < count; i++)
                {
                    if(i == index)
                    {
                        return current.Data;
                    }
                    else
                    {
                        current = current.next;
                    }
                }
                return current.Data;
            }
        }
    }
}
