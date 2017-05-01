using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegBoard
{
    /// <summary>
    /// The class used to represent each peg on the board
    /// </summary>
    class Peg
    {
        public bool Empty { get; set; }
        /// <summary>
        /// The number of the peg on the board
        /// </summary>
        public int Number { get; set; }

        public Peg(int number, bool empty)
        {
            this.Empty = empty;
            this.Number = number;
        }

        /// <summary>
        /// Gets a list of valid moves for this peg
        /// </summary>
        /// <returns></returns>
        public List<Move> PossibleMoves()
        {
            List<int> adjacents;
            List<Move> moves = new List<Move>();
            switch (Number)
            {
                case 0:
                    adjacents = new List<int> { 3, 5 };
                    break;
                case 1:
                    adjacents = new List<int> { 6, 8 };
                    break;
                case 2:
                    adjacents = new List<int> { 7, 9 };
                    break;
                case 3:
                    adjacents = new List<int> { 0, 5, 10, 12 };
                    break;
                case 4:
                    adjacents = new List<int> { 11, 13 };
                    break;
                case 5:
                    adjacents = new List<int> { 0, 3, 12, 14 };
                    break;
                case 6:
                    adjacents = new List<int> { 1, 8 };
                    break;
                case 7:
                    adjacents = new List<int> { 2, 9 };
                    break;
                case 8:
                    adjacents = new List<int> { 1, 6 };
                    break;
                case 9:
                    adjacents = new List<int> { 2, 7 };
                    break;
                case 10:
                    adjacents = new List<int> { 3, 12 };
                    break;
                case 11:
                    adjacents = new List<int> { 4, 13 };
                    break;
                case 12:
                    adjacents = new List<int> { 3, 5, 10, 14 };
                    break;
                case 13:
                    adjacents = new List<int> { 4, 11 };
                    break;
                default:
                    adjacents = new List<int> { 5, 12 };
                    break;
            }

            foreach(int i in adjacents)
            {
                Move m = Possible(i);
                if (m != null)
                {
                    moves.Add(m);
                }
            }

            return moves;
        }

        /// <summary>
        /// Check if an adjacent peg is available to move to
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Move Possible(int n)
        {
            if (!Board.pegs[n].Empty && !Board.pegs[GetMiddle(Number, n)].Empty)
                return new Move(n, Number);
            else
                return null;
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
    }
}

