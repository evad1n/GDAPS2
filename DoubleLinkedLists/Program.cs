using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            CustomLinkedList<string> list = new CustomLinkedList<string>();
            string input = null;

            //Loop for user input
            while(input != "q" && input != "quit")
            {
                Console.WriteLine("What you wanna do son?");
                input = Console.ReadLine();

                if(input == "count")
                {
                    Console.WriteLine("There are " + list.Count + " items in this list.");
                }
                else if (input == "clear")
                {
                    list.Clear();
                    Console.WriteLine("The list has been cleared.");
                }
                else if (input == "print")
                {
                    Console.WriteLine("The following items are in the list: ");
                    list.Print();
                }
                //Move an element in the list to a new position
                else if (input == "scramble")
                {
                    try
                    {
                        list.Insert(list.Remove(r.Next(list.Count)), r.Next(list.Count));
                        Console.WriteLine("A random element has been moved to a new position.");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }                                      
                }
                //Remove a random element in the list
                else if (input == "remove")
                {
                    try
                    {
                        list.Remove(r.Next(list.Count));
                        Console.WriteLine("A random element has been removed from the list");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                //Otherwise add whatever the user typed to the list
                else
                {
                    Console.WriteLine(input + " has been added to the list.");
                    list.Add(input);
                }
            }
            Console.WriteLine("Bye..");
        }
    }
}
