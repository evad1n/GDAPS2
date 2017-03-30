using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class PriorityQueue
    {
        List<int> list;

        public bool IsEmpty
        {
            get { return list.Count == 0; }
        }

        public PriorityQueue()
        {
            list = new List<int>();
        }

        public void Enqueue(int data)
        {
            list.Add(data);
            int index = list.Count - 1;
            while(list[(index - 1) / 2] > list[index])
            {
                int temp = list[(index - 1) / 2];
                list[(index - 1) / 2] = list[index];
                list[index] = temp;
                index = (index - 1) / 2;
            }
        }

        public int Dequeue()
        {
            int index = 0;
            int root = list[0];
            list[0] = list.Last();
            list.RemoveAt(list.Count - 1);
            //Check if there are child nodes
            while ((2 * index) + 1 < list.Count || (2 * index) + 2 < list.Count) 
            {
                int leftNode = 0;
                int rightNode = 0;
                if ((2 * index) + 1 < list.Count)
                    leftNode = 2 * index + 1;
                if((2 * index) + 2 < list.Count)
                    rightNode = 2 * index + 2;

                //Check if greater than both nodes
                if (leftNode != 0 && rightNode != 0 && list[index]> list[leftNode] && list[index] > list[rightNode])
                {
                    if (list[leftNode] > list[rightNode])
                    {
                        int temp = list[index];
                        list[index] = list[rightNode];
                        list[rightNode] = temp;
                    }
                    else
                    {
                        int temp = list[index];
                        list[index] = list[leftNode];
                        list[leftNode] = temp;
                    }
                }
                //Check if greater than left node
                else if (leftNode != 0 && list[index] > list[leftNode])
                {
                    int temp = list[index];
                    list[index] = list[leftNode];
                    list[leftNode] = temp;
                }
                //Check if greater than right node
                else if (rightNode != 0 && list[index] > list[rightNode])
                {
                    int temp = list[index];
                    list[index] = list[rightNode];
                    list[rightNode] = temp;
                }
                index++;
            }
            return root;
        }

        public int Peek()
        {
            return list[0];
        }
    }
}
