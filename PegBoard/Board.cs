using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegBoard
{
    /// <summary>
    /// The class that represents a board of 15 pegs
    /// </summary>
    class Board
    {
        List<Peg> pegs;
        int startPeg;

        public Board(int emptyPeg)
        {
            this.startPeg = emptyPeg;
            pegs = new List<Peg>();

            //Set up board
            for (int i = 0; i < 15; i++)
            {
                if (i != emptyPeg)
                    pegs.Add(new Peg(i, false));
                else
                    pegs.Add(new Peg(i, true));
            }
        }

        public void Move(int emptyPeg)
        {
            List<int> moves = pegs[emptyPeg].GetAdjacents();
            foreach (int m in moves)
            {
                if (!pegs[m].Empty)
                {
                    Move(m);
                }
            }
        }

        public int Jump(int start, int end)
        {
            int m = Math.Abs(end - start);
            m /= 2;
            if (start > end)
            {
                return m + end;
            }
            else
            {
                return m + start;
            }
        }
    }
}
