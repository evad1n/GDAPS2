using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Physics
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        World world;
        Body balloonBody;
        List<Vector2> positions;
        List<Body> bodies;

        Vector2 hitForce;

        SpriteFont font;
        Texture2D balloonTexture;

        int score;
        string time;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            positions = new List<Vector2>();
            bodies = new List<Body>();
            world = new World(new Vector2(0,-9.8f));
            score = 0;
            time = "";
            hitForce = new Vector2(0, 10100101f);
            world.Step(0.5f);

            balloonBody = BodyFactory.CreateCircle(world, 1, 1);
            //FixtureFactory.AttachCircle(1,1, balloonBody);
            balloonBody.Position = new Vector2(0,0);
            balloonBody.BodyType = BodyType.Dynamic;

            positions.Add(balloonBody.Position);
            bodies.Add(balloonBody);
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
            balloonTexture = Content.Load<Texture2D>("balloon");
            font = Content.Load<SpriteFont>("font");
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

            time = gameTime.ElapsedGameTime.Minutes + ":" + gameTime.ElapsedGameTime.Seconds;

            if (gameTime.ElapsedGameTime.Seconds > 5)
            {
                positions.Add(CreateBalloon());
            }

            HandleInput();

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

            for(int i = 0; i < positions.Count; i++)
            {
                spriteBatch.Draw(balloonTexture, position: positions[i], scale: new Vector2(0.8f));
            }

            spriteBatch.DrawString(font, "Score: " + score + "  Time: " + time, new Vector2(600, 0), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public Vector2 CreateBalloon()
        {
            balloonBody = new Body(world);
            FixtureFactory.AttachCircle(1, 1, balloonBody);
            balloonBody.Position = new Vector2(0, 0);

            return balloonBody.Position;
        }

        public void HandleInput()
        {
            if(Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                for(int i = 0; i < positions.Count; i++)
                {
                    if (Mouse.GetState().Position.X > positions[i].X - 5 && Mouse.GetState().Position.X < positions[i].X + 5)
                    {
                        if (Mouse.GetState().Position.Y > positions[i].Y - 5 && Mouse.GetState().Position.Y < positions[i].Y + 5)
                        {
                            score += 100;
                            bodies[i].ApplyForce(hitForce);
                        }
                    }
                }
            }
        }
    }
}
