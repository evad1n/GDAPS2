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
        public int Number { get; set; }

        public Peg(int number, bool empty)
        {
            this.Empty = empty;
            this.Number = number;
        }

        public List<int> GetAdjacents()
        {
            switch (Number)
            {
                case 0:
                    return new List<int> { 3, 5 };
                case 1:
                    return new List<int> { 6, 8 };
                case 2:
                    return new List<int> { 7, 9 };
                case 3:
                    return new List<int> { 0, 5, 10, 12 };
                case 4:
                    return new List<int> { 11, 13 };
                case 5:
                    return new List<int> { 0, 3, 12, 14 };
                case 6:
                    return new List<int> { 1, 8 };
                case 7:
                    return new List<int> { 2, 9 };
                case 8:
                    return new List<int> { 1, 6 };
                case 9:
                    return new List<int> { 2, 7 };
                case 10:
                    return new List<int> { 3, 12 };
                case 11:
                    return new List<int> { 4, 13 };
                case 12:
                    return new List<int> { 3, 5, 10, 14 };
                case 13:
                    return new List<int> { 4, 11 };
                default:
                    return new List<int> { 5, 12 };
            }
        }
    }
}

