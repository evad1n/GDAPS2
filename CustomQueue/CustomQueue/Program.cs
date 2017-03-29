using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomQueue
{
	class Program
	{
		static void Main(string[] args)
		{
            GameQueue queue = new GameQueue(12);

            queue.Enqueue("Bob");
            queue.Enqueue("Jim");
            queue.Enqueue("Fred");
            queue.Enqueue("Tim");
            queue.Enqueue("Alex");
            queue.Enqueue("Ted");
            queue.Enqueue("Noah");
            queue.Enqueue("Blake");
            queue.Enqueue("Mark");
            queue.Enqueue("Will");
            queue.Enqueue("Chad");
            queue.Enqueue("Liam");
            
            for(int i = 0; i <queue.; i++)
            {
                Console.WriteLine("Player " + queue.Dequeue() + " has joined the server: " + queue.Count + " player(s) left in the queue");
            }
        }
	}
}
