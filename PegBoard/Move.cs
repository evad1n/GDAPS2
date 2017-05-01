using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegBoard
{
    /// <summary>
    /// Represents a move between 2 pegs
    /// </summary>
    class Move
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Middle { get; set; }

        public Move(int start, int end)
        {
            Start = start;
            End = end;
            Middle = GetMiddle(start, end);
        }

        //Get the middle peg when a move is performed
        public int GetMiddle(int start, int end)
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

        public override string ToString()
        {
            return "From: " + Start + " To: " + End + "\r\n";
        }
    }
}
