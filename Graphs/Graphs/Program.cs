using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            AdjacencyList list = new AdjacencyList();

            string input = "";
            //Starting room
            string room = "library";

            while(room != "exit")
            {
                Console.WriteLine("You are currently in the: " + room);
                Console.Write("Nearby are: ");
                foreach(string s in list.GetAdjacentList(room))
                {
                    Console.Write(s + "   ");
                }
                Console.WriteLine("\nWhere would you like to go? ");
                input = Console.ReadLine();

                if(list.IsConnected(room, input))
                {
                    room = input;
                }
                else
                {
                    Console.WriteLine("That ain't no room nearby!");
                }
            }

            Console.WriteLine("Wow, great job, you did it...");
        }
    }
}
