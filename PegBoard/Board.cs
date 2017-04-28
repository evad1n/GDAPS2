using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Submit a PLAIN TEXT file named “solution.txt” that contains the following:

Your name.

A brief description of your approach to the problem.

A short description of each data structure used and its purpose.
*/

namespace PegBoard
{
    /// <summary>
    /// The class that represents a board of 15 pegs
    /// </summary>
    class Board
    {
        List<Peg> pegs;
        int startPeg;
        StringBuilder sb;
        int count;

        public Board(int emptyPeg)
        {
            this.startPeg = emptyPeg;
            pegs = new List<Peg>();
            sb = new StringBuilder();
            count = 14;

            //Set up board
            for (int i = 0; i < 15; i++)
            {
                if (i != emptyPeg)
                    pegs.Add(new Peg(i, false));
                else
                    pegs.Add(new Peg(i, true));
            }
        }

        public string Solve()
        {
            string s = "Starting Empty Peg: " + startPeg + "\r\n";
            while (count > 1)
            {
                s += (Move(startPeg));
            }
            return s;
        }

        public string Move(int emptyPeg)
        {
            int start = 0;
            int end = emptyPeg;
            List<int> moves = pegs[emptyPeg].GetAdjacents();
            foreach (int m in moves)
            {
                if (!pegs[m].Empty && !pegs[Jump(m, emptyPeg)].Empty)
                {
                    
                }
            }
            count--;
            start = m;
            pegs[m].Empty = true;
            pegs[Jump(m, emptyPeg)].Empty = true;
            pegs[end].Empty = false;
            return "From: " + start + " To: " + end + "\r\n" + Move(m) + Move(Jump(m, emptyPeg));
            return null;
        }
    }
}
