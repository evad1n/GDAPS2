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
        /// <summary>
        /// The number of this move (e.g. The fifth move is 5)
        /// </summary>
        public int Count { get; set; }

        public Move(int start, int end, int count)
        {
            Start = start;
            End = end;
            Count = count;
            Middle = GetMiddle(start, end);
        }

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
    }
}
