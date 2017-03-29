using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
	class Program
	{
		static void Main(string[] args)
		{
            GameStack stack = new GameStack(15);
            stack.Push("Finish");
            stack.Push("Repeat");
            stack.Push("Rinse");
            stack.Push("Wake up");
            stack.Push("Go to bed");
            stack.Push("Drink liquid");
            stack.Push("Eat food");
            stack.Push("Kill me");
            stack.Push("Cry");
            stack.Push("Multiply by infinity");
            stack.Push("Throw error");
            stack.Push("Divide by 0");
            stack.Push("Subtract 2");
            stack.Push("Add 2");
            stack.Push("Start");

            while(stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
	}
}
