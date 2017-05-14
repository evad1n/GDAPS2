using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace AStar
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static Texture2D texture;

        //These can be changed easily
        public const int TILE_SIZE = 40;
        public const int TILE_COUNT = 20;

        public static Vertex[,] map = new Vertex[TILE_COUNT, TILE_COUNT];

        Vertex start;
        Vertex end;

        PriorityQueue open;
        List<Vertex> closed;
        bool done = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = TILE_SIZE * TILE_COUNT;
            graphics.PreferredBackBufferHeight = TILE_SIZE * TILE_COUNT;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //Create map
            for (int x = 0; x < TILE_COUNT; x++)
            {
                for (int y = 0; y < TILE_COUNT; y++)
                {
                    map[x, y] = new Vertex(x,y);
                }
            }

            start = map[0, 0];
            end = map[TILE_COUNT - 1, TILE_COUNT - 1];

            //Add obstacles
            //These end up being vertical walls that alternate between cutting off the top part of the screen and the bottom to make pathfinding more difficult
            for (int x = 3; x < TILE_COUNT; x+= 3)
            {
                for (int y = 2; y < TILE_COUNT - 2; y++)
                {
                    map[x, y].Empty = false;
                }
            }

            for (int x = 6; x < TILE_COUNT; x += 6)
            {
                for (int y = 2; y < TILE_COUNT; y++)
                {
                    map[x, y].Empty = false;
                }
            }

            for (int x = 3; x < TILE_COUNT; x += 6)
            {
                for (int y = 0; y < 2; y++)
                {
                    map[x, y].Empty = false;
                }
            }

            //Make sure these are empty
            start.Empty = true;
            end.Empty = true;

            open = new PriorityQueue();
            open.Enqueue(start);
            closed = new List<Vertex>();
            start.Cost = 0;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            texture = Content.Load<Texture2D>("rect");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (!done)
                Solve();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            for(int x = 0; x < TILE_COUNT; x++)
            {
                for(int y = 0; y < TILE_COUNT; y++)
                {
                    if(!map[x, y].Empty)
                        map[x, y].Draw(spriteBatch, Color.DarkGray);
                    else
                        map[x, y].Draw(spriteBatch, Color.White);
                }
            }
            //Draw open list
            foreach(Vertex v in open.list)
            {
                v.Draw(spriteBatch, Color.Tan);
            }
            //Draw closed list
            foreach (Vertex v in closed)
            {
                v.Draw(spriteBatch, Color.Beige);
            }
            //Draw final path
            if(done)
            {
                Vertex v = end.Parent;
                while(v != start)
                {
                    v.Draw(spriteBatch, Color.Yellow);
                    v = v.Parent;
                }
            }
            //Draw other static stuff
            start.Draw(spriteBatch, Color.Green);
            end.Draw(spriteBatch, Color.Red);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// A* algorithm
        /// Mostly taken from http://theory.stanford.edu/~amitp/GameProgramming/ImplementationNotes.html
        /// </summary>
        public void Solve()
        {
            Vertex min = open.Dequeue();
            if(!min.Equals(end))
            {
                closed.Add(min);
                foreach(Vertex v in min.Adjacents)
                {
                    if (v.Equals(end))
                        Console.WriteLine("");
                    int cost = min.Cost + 1;
                    if (open.list.Contains(v) && cost < v.Cost)
                        open.list.Remove(v);
                    if (closed.Contains(v) && cost < v.Cost)
                        closed.Remove(v);
                    if(!open.list.Contains(v) && !closed.Contains(v))
                    {
                        v.Cost = cost;
                        v.Priority = v.Cost + Heuristic(v);
                        open.Enqueue(v);
                        v.Parent = min;
                    }
                }
            }
            else
            {
                done = true;
            }
        }

        /// <summary>
        /// Heuristic function for A*
        /// This takes into account the type of map I use so it is much faster by not caring about the y value much and 
        /// putting emphasis on the x value
        /// This heuristic wouldn't work well on other map types but I decided to try it out to see if I could make a heuristic that
        /// was more efficient for a certain type of map
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public int Heuristic(Vertex v)
        {
            int x = v.X - end.X;
            int y = v.Y - end.Y;
            x = Math.Abs(x);
            y = Math.Abs(y);
            x *= 5;
            return 20 * (x + y/20);
        }
    }
}
