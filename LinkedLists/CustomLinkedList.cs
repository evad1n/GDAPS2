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

        public CustomLinkedNode<T> tail { get; set; }

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
                current = newNode;
                tail = newNode;
                count = 1;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
                count++;
            }
        }

        public T Remove(int index)
        {
            var current = head;
            T removed;
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("That index is not in the list");
            }
            else if (index == 0)
            {
                removed = head.Data;
                head = head.next;
            }
            else if (index == (count - 1))
            {
                removed = tail.Data;
                for (int i = 0; i < count; i++)
                {
                    if (i == index - 1)
                    {
                        break;
                    }
                    else
                    {
                        current = current.next;
                    }
                }
                tail = current;
                current.next = null;
            }
            else if (count == 1)
            {
                removed = head.Data;
                head = null;
                tail = null;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (i == index - 1)
                    {
                        break;
                    }
                    else
                    {
                        current = current.next;
                    }
                }
                removed = current.next.Data;
                current.next = current.next.next;
            }
            count--;
            return removed;
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
                        break;
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
