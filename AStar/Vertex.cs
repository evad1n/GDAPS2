using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    /// <summary>
    /// Represents a tile on the screen
    /// </summary>
    public class Vertex
    {
        public bool Empty { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Vertex Parent { get; set; }

        public int Cost { get; set; }

        /// <summary>
        /// The priority for the priority queue
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Returns the 4 adjacent tiles if they are in the map and not obstructed (an obstacle)
        /// </summary>
        public List<Vertex> Adjacents
        {
            get
            {
                List<Vertex> list = new List<Vertex>();

                if (X + 1 < Game1.TILE_COUNT && Game1.map[X+1,Y].Empty)
                    list.Add(Game1.map[X + 1, Y]);
                if (X - 1 >= 0 && Game1.map[X - 1, Y].Empty)
                    list.Add(Game1.map[X - 1, Y]);
                if (Y + 1 < Game1.TILE_COUNT && Game1.map[X, Y + 1].Empty)
                    list.Add(Game1.map[X, Y + 1]);
                if (Y - 1 >= 0 && Game1.map[X, Y - 1].Empty)
                    list.Add(Game1.map[X, Y - 1]);

                return list;
            }
        }

        public Vertex(int x, int y, bool empty = true)
        {
            Empty = empty;
            X = x;
            Y = y;
            Cost = int.MaxValue;
            Priority = 0;
        }

        public void Draw(SpriteBatch sb, Color color)
        {
            sb.Draw(Game1.texture, new Rectangle(X * Game1.TILE_SIZE, Y * Game1.TILE_SIZE, Game1.TILE_SIZE, Game1.TILE_SIZE), color);
        }

        /// <summary>
        /// For comparing and testing equality based on map position
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool Equals(Vertex v)
        {
            if (v.X == X && v.Y == Y)
                return true;
            else
                return false;
        }
    }
}
