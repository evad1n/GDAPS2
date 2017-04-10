using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class AdjacencyList
    {
        Dictionary<string, List<string>> dict;

        public AdjacencyList()
        {
            dict = new Dictionary<string, List<string>>();
            dict.Add("kitchen", new List<string>{ "library", "bedroom", "dining room" });
            dict.Add("bedroom", new List<string> { "kitchen" });
            dict.Add("library", new List<string> { "bathroom", "kitchen" });
            dict.Add("dining room", new List<string> { "kitchen", "exit", "hallway" });
            dict.Add("bathroom", new List<string> { "library", "sunroom" });
            dict.Add("sunroom", new List<string> { "bathroom", "hallway" });
            dict.Add("hallway", new List<string> { "sunroom", "dining room" });
            dict.Add("exit", new List<string> { "dining room" });
        }

        public List<String> GetAdjacentList(string room)
        {
            return dict[room];
        }

        public bool IsConnected(string room1, string room2)
        {
            if (dict[room1].Contains(room2))
            {
                return true;
            }
            return false;
        }
    }
}
