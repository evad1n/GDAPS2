using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Graph
    {

        int[,] adjacency;
        Dictionary<string, Vertex> dict;
        List<Vertex> list;

        public Graph()
        {
            dict = new Dictionary<string, Vertex>();
            list = new List<Vertex>();
            adjacency = new int[5, 5];

            Vertex v = new Vertex("library", 0);
            dict.Add(v.name, v);
            list.Add(v);
            adjacency[1, v.number] = 1;
            adjacency[3, v.number] = 1;

            v = new Vertex("hallway", 1);
            dict.Add(v.name, v);
            list.Add(v);
            list.Add(v);
            adjacency[0, v.number] = 1;
            adjacency[4, v.number] = 1;

            v = new Vertex("bathroom", 2);
            dict.Add(v.name, v);
            list.Add(v);
            list.Add(v);
            adjacency[3, v.number] = 1;
            adjacency[4, v.number] = 1;

            v = new Vertex("kitchen", 3);
            dict.Add(v.name, v);
            list.Add(v);
            adjacency[0, v.number] = 1;
            adjacency[2, v.number] = 1;
            adjacency[4, v.number] = 1;

            v = new Vertex("bedroom", 4);
            dict.Add(v.name, v);
            list.Add(v);
            adjacency[1, v.number] = 1;
            adjacency[2, v.number] = 1;
            adjacency[3, v.number] = 1;

        }

        public void Reset()
        {
            foreach(Vertex v in list)
            {
                v.visited = false;
            }
        }

        public Vertex GetAdjacentUnvisited(string name)
        {
            int r = list.IndexOf(dict[name]);
            for (int i = 0; i < adjacency.GetLength(1); i++)
            {
                if(adjacency[r,i] == 1)
                {
                    if(list[i].visited == false)
                    {
                        return list[i];
                    }
                }
            }
            return null;
        }

        public void DepthFirst(string name)
        {
            if(!dict.ContainsKey(name))
            {
                Console.WriteLine("That is not a valid name");
                return;
            }

            Reset();

            Stack<Vertex> stack = new Stack<Vertex>();

            Vertex v = dict[name];

            Console.WriteLine(v.name);
            stack.Push(v);
            v.visited = true;

            while(stack.Count != 0)
            {
                v = GetAdjacentUnvisited(stack.Peek().name);
                if(v != null)
                {
                    Console.WriteLine(v.name);
                    stack.Push(v);
                    v.visited = true;
                }
                else
                {
                    stack.Pop();
                }
            }
        }
    }
}
