using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            //Part 1
            //for(int i = 0; i < 10; i++)
            //{
            //    NumberPrinter num = new NumberPrinter(i);
            //    for(int j = 0; j < 5; j++)
            //    {
            //        Thread t = new Thread(num.Print);
            //        t.Start();
            //    }
            //}

            //Part 2
            GamePlay g1 = new GamePlay("Physics");
            GamePlay g2 = new GamePlay("Math");
            GamePlay g3 = new GamePlay("Stupid");
            GamePlay g4 = new GamePlay("Death");
            GamePlay g5 = new GamePlay("Help");

            List<Thread> list = new List<Thread>();
            Thread t1 = new Thread(g1.Update);
            Thread t2 = new Thread(g2.Update);
            Thread t3 = new Thread(g3.Update);
            Thread t4 = new Thread(g4.Update);
            Thread t5 = new Thread(g5.Update);
            list.Add(t1);
            list.Add(t2);
            list.Add(t3);
            list.Add(t4);
            list.Add(t5);

            foreach (Thread t in list)
            {
                t.Start();
            }
            Console.WriteLine("Update Complete! Time to Draw");
        }
    }
}
