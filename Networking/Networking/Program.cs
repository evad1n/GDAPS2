using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Networking
{
    class Program
    {
        static void Main(string[] args)
        {

            TcpClient client = new TcpClient("129.21.29.140", 14623);
            StreamWriter stream = new StreamWriter(client.GetStream());

            string input = "";
            while(input != "quit")
            {
                input = Console.ReadLine();
                stream.WriteLine(input);
                stream.Flush();

                if(input == "loop")
                {
                    for(int i = 0; i < 100; i++)
                    {
                        stream.WriteLine("KAPPA");
                        stream.Flush();
                    }
                }

                if (input == "lol")
                {
                    for (int i = 0; i < 100; i++)
                    {
                        stream.WriteLine("CALL 911 PLEASE LORD SAVE ME THE DEVIL IS INSIDE OF ME!!!!");
                        stream.Flush();
                    }
                }

                if (input == "cancer")
                {
                    int j = 0;
                    while(input != "abc")
                    {
                        j++;
                        for(int i = 0; i < j; i++)
                        {
                            input += " " + input;
                            if(i > 50)
                            {
                                i = 0;
                            }
                            stream.WriteLine(input);
                        }
                        stream.WriteLine("CALL 911 PLEASE LORD SAVE ME THE DEVIL IS INSIDE OF ME!!!!CALL 911 PLEASE LORD SAVE ME THE DEVIL IS INSIDE OF ME!!!!CALL 911 PLEASE LORD SAVE ME THE DEVIL IS INSIDE OF ME!!!!CALL 911 PLEASE LORD SAVE ME THE DEVIL IS INSIDE OF ME!!!!CALL 911 PLEASE LORD SAVE ME THE DEVIL IS INSIDE OF ME!!!!CALL 911 PLEASE LORD SAVE ME THE DEVIL IS INSIDE OF ME!!!!CALL 911 PLEASE LORD SAVE ME THE DEVIL IS INSIDE OF ME!!!!CALL 911 PLEASE LORD SAVE ME THE DEVIL IS INSIDE OF ME!!!!CALL 911 PLEASE LORD SAVE ME THE DEVIL IS INSIDE OF ME!!!!CALL 911 PLEASE LORD SAVE ME THE DEVIL IS INSIDE OF ME!!!!");
                        stream.Flush();
                    }
                }
            }
        }
    }
}
