using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class GamePlay
    {
        string name;

        public GamePlay(string name)
        {
            this.name = name;
        }

        public void Update()
        {
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine(name + ":" + i * 10 + "% Complete");
            }
        }
    }
}
