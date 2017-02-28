using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class NumberPrinter
    {
        int number;

        public NumberPrinter(int number)
        {
            this.number = number;
        }

        public void Print()
        {
            Console.ForegroundColor = (ConsoleColor)(number % 16);

            for (int i = 0; i < 10; i++)
            {
                Console.Write(number + " ");
            }
        }
    }
}
