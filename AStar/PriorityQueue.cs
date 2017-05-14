using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    /// <summary>
    /// Had to be changed a bit for Vertices but was basically just replacing all instances of comparing data with comparing of the Verterx.Priority
    /// </summary>
    class PriorityQueue
    {
        public List<Vertex> list;

        public bool IsEmpty
        {
            get { return list.Count == 0; }
        }

        public PriorityQueue()
        {
            list = new List<Vertex>();
        }

        public void Enqueue(Vertex v)
        {
            list.Add(v);
            int index = list.Count - 1;
            while (list[(index - 1) / 2].Priority > list[index].Priority)
            {
                Vertex temp = list[(index - 1) / 2];
                list[(index - 1) / 2] = list[index];
                list[index] = temp;
                index = (index - 1) / 2;
            }
        }

        public Vertex Dequeue()
        {
            int index = 0;
            Vertex root = list[0];
            list[0] = list.Last();
            list.RemoveAt(list.Count - 1);
            //Check if there are child nodes
            while ((2 * index) + 1 < list.Count || (2 * index) + 2 < list.Count)
            {
                int leftNode = 0;
                int rightNode = 0;
                if ((2 * index) + 1 < list.Count)
                    leftNode = 2 * index + 1;
                if ((2 * index) + 2 < list.Count)
                    rightNode = 2 * index + 2;

                //Check if greater than both nodes
                if (leftNode != 0 && rightNode != 0 && list[index].Priority > list[leftNode].Priority && list[index].Priority > list[rightNode].Priority)
                {
                    if (list[leftNode].Priority > list[rightNode].Priority)
                    {
                        Vertex temp = list[index];
                        list[index] = list[rightNode];
                        list[rightNode] = temp;
                    }
                    else
                    {
                        Vertex temp = list[index];
                        list[index] = list[leftNode];
                        list[leftNode] = temp;
                    }
                }
                //Check if greater than left node
                else if (leftNode != 0 && list[index].Priority > list[leftNode].Priority)
                {
                    Vertex temp = list[index];
                    list[index] = list[leftNode];
                    list[leftNode] = temp;
                }
                //Check if greater than right node
                else if (rightNode != 0 && list[index].Priority > list[rightNode].Priority)
                {
                    Vertex temp = list[index];
                    list[index] = list[rightNode];
                    list[rightNode] = temp;
                }
                index++;
            }
            return root;
        }

        public Vertex Peek()
        {
            return list[0];
        }
    }
}

