using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Vertex
    {
        public string name;
        public bool visited;
        public int number;
        public int distance = int.MaxValue;
        public Vertex neighbor;

        public Vertex(string name, int number)
        {
            this.name = name;
            this.number = number;
            visited = false;
        }
    }
}
