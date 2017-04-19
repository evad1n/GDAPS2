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
        public bool permanent;
        public int number;
        public int distance;
        public Vertex neighbor;

        public Vertex(string name, int number)
        {
            this.name = name;
            this.number = number;
            visited = false;
            permanent = false;
            distance = int.MaxValue;
        }
    }
}
