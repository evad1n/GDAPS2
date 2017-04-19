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
            adjacency = new int[6, 6];

            Vertex v = new Vertex("library", 0);
            dict.Add(v.name, v);
            list.Add(v);
            adjacency[1, v.number] = 1;
            adjacency[3, v.number] = 1;

            v = new Vertex("hallway", 1);
            dict.Add(v.name, v);
            list.Add(v);
            adjacency[0, v.number] = 1;
            adjacency[4, v.number] = 1;

            v = new Vertex("bathroom", 2);
            dict.Add(v.name, v);
            list.Add(v);
            adjacency[3, v.number] = 1;
            adjacency[4, v.number] = 1;
            adjacency[5, v.number] = 1;

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
            adjacency[5, v.number] = 1;

            v = new Vertex("attic", 5);
            dict.Add(v.name, v);
            list.Add(v);
            adjacency[2, v.number] = 1;
            adjacency[4, v.number] = 1;



            /*        , A
             * H - Be   |
             *         Ba
             * L - K
             * 
             * 
             */

        }

        public void Reset()
        {
            foreach(Vertex v in list)
            {
                v.visited = false;
                v.distance = int.MaxValue;
            }
        }

        public Vertex GetAdjacentUnvisited(string name)
        {
            int r = list.IndexOf(dict[name]);
            for (int i = 0; i < adjacency.GetLength(1); i++)
            {
                if(adjacency[i,r] == 1)
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

        public void ShortestPath(string name)
        {
            Reset();

            Vertex current = dict[name];

            Vertex v = dict[name];
            v.distance = 0;
            v.permanent = true;
            v.visited = true;

            while (list.Where(s => s.permanent == false).ToList().Count != 0)
            {
                v = GetAdjacentUnvisited(current.name);
                if (v != null)
                {
                    int dist = current.distance + adjacency[list.IndexOf(current), list.IndexOf(v)];
                    if (dist < v.distance)
                    {
                        v.distance = dist;
                        v.visited = true;
                        v.neighbor = current;
                    }
                }
                else
                {
                    int min = int.MaxValue;
                    foreach(Vertex vert in list.Where(s => s.permanent == false).ToList())
                    {
                        if(vert.distance < min)
                        {
                            min = vert.distance;
                            current = vert;
                        }
                    }
                    current.permanent = true;
                }
            }
        }

        public void Path(string source, string destination)
        {
            if(!dict.ContainsKey(destination))
            {
                Console.WriteLine("That is not a valid room");
                return;
            }
            Console.WriteLine("The shortest path is: ");

            Vertex start = dict[source];
            Vertex end = dict[destination];
            Vertex current = end;

            while(current != start)
            {
                Console.WriteLine(current.name);
                current = current.neighbor;
            }

            Console.WriteLine(start.name + "\n");
        }
    }
}
