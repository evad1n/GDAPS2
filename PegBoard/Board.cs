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
        public static List<Peg> pegs;
        int startPeg;
        int count;

        List<Move> moves;

        public Board(int emptyPeg)
        {
            this.startPeg = emptyPeg;
            pegs = new List<Peg>();
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
            moves = new List<Move>();
            string s = "Starting Empty Peg: " + startPeg + "\r\n";
            Go();
            s += "Number of moves: " + (14 - count) + "\r\n";
            foreach(Move m in moves)
            {
                s += m.ToString();
            }
            return s;
        }
        /// <summary>
        /// Recursive/Backtracking solving function
        /// </summary>
        /// <returns></returns>
        public bool Go()
        {
            Update();

            if (count == 1)
            {
                return true;
            }
            else
            {
                foreach (Peg p in GetEmptyPegs())
                {
                    foreach (Move m in p.PossibleMoves())
                    {
                        moves.Add(m);
                        Update();
                        if (Go())
                        {
                            return true;
                        }
                        else
                        {
                            moves.RemoveAt(moves.Count - 1);
                            Update();
                        }
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Get all empty pegs on the board
        /// </summary>
        /// <returns></returns>
        public List<Peg> GetEmptyPegs()
        {
            List<Peg> empties = new List<Peg>();
            foreach(Peg p in pegs)
            {
                if (p.Empty)
                    empties.Add(p);
            }

            return empties;
        }

        /// <summary>
        /// Updates board based on moves in stack
        /// </summary>
        public void Update()
        {
            Reset();
            count = 14;
            foreach(Move m in moves)
            {
                count--;
                pegs[m.Start].Empty = true;
                pegs[m.Middle].Empty = true;
                pegs[m.End].Empty = false;
            }
        }

        /// <summary>
        /// Resets board
        /// </summary>
        public void Reset()
        {
            for (int i = 0; i < 15; i++)
            {
                if (i != startPeg)
                    pegs[i] = new Peg(i, false);
                else
                    pegs[i] = new Peg(i, true);
            }
        }
    }
}
