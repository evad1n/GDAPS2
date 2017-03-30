using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            PriorityQueue priorityQueue = new PriorityQueue();

            priorityQueue.Enqueue(rand.Next(50));
            priorityQueue.Enqueue(rand.Next(50));
            priorityQueue.Enqueue(rand.Next(50));
            priorityQueue.Enqueue(rand.Next(50));
            priorityQueue.Enqueue(rand.Next(50));
            priorityQueue.Enqueue(rand.Next(50));
            priorityQueue.Enqueue(rand.Next(50));
            priorityQueue.Enqueue(rand.Next(50));
            priorityQueue.Enqueue(rand.Next(50));
            priorityQueue.Enqueue(rand.Next(50));
            priorityQueue.Enqueue(rand.Next(50));
            priorityQueue.Enqueue(rand.Next(50));

            while(!priorityQueue.IsEmpty)
            {
                Console.WriteLine(priorityQueue.Dequeue());
            }
        }
    }
}
