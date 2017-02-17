using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Physics
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const float unitToPixel = 100.0f;
        const float pixelToUnit = 1 / unitToPixel;

        static MouseState prevM;

        World world;
        Body balloonBody;
        Fixture balloonFixture;
        List<Fixture> fixtures;

        Vector2 hitForce;
        Random rand;

        SpriteFont font;
        Texture2D balloonTexture;

        int score;
        string time;
        float timer;

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
            fixtures = new List<Fixture>();
            rand = new Random();
            world = new World(new Vector2(0,9.8f));
            score = 0;
            time = "";
            hitForce = new Vector2(0, -100000000f);

            this.IsMouseVisible = true;

            balloonBody = BodyFactory.CreateRectangle(world, 5f * pixelToUnit, 5f * pixelToUnit, 0.001f);
            balloonFixture = balloonBody.CreateFixture(new CircleShape(1f, 1));
            balloonFixture.Body.Position = new Vector2((GraphicsDevice.Viewport.Width / 2.0f) * pixelToUnit,0);
            balloonBody.BodyType = BodyType.Dynamic;

            fixtures.Add(balloonFixture);

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
            balloonTexture = Content.Load<Texture2D>("balloon2");
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
            world.Step(0.067f);

            time = string.Format("{0:0.00}",(float)gameTime.TotalGameTime.TotalSeconds);

            timer += (float)gameTime.ElapsedGameTime.Milliseconds;

            if (timer > 5000)
            {
                CreateBalloon();
                timer = 0;
            }

            for(int i = 0; i < fixtures.Count; i++)
            {
                if(fixtures[i].Body.Position.Y > GraphicsDevice.Viewport.Height)
                {
                    fixtures[i].Dispose();
                    fixtures.RemoveAt(i);
                }
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

            for (int i = 0; i < fixtures.Count; i++)
            {
                spriteBatch.Draw(balloonTexture, fixtures[i].Body.Position, scale: new Vector2(0.5f));
            }

            spriteBatch.DrawString(font, "Score: " + score + "  Time: " + time, new Vector2(600, 0), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void CreateBalloon()
        {
            balloonBody = BodyFactory.CreateRectangle(world, 5f * pixelToUnit, 5f * pixelToUnit, 1);
            balloonFixture = balloonBody.CreateFixture(new CircleShape(1f, 0.001f));
            balloonFixture.Body.Position = new Vector2(rand.Next(50, GraphicsDevice.Viewport.Width - 50), rand.Next(0, 100));
            balloonBody.BodyType = BodyType.Dynamic;

            fixtures.Add(balloonFixture);

        }

        public void HandleInput()
        {
            var m = Mouse.GetState();

            if (m.LeftButton == ButtonState.Pressed && prevM.LeftButton == ButtonState.Released)
            {
                for (int i = 0; i < fixtures.Count; i++)
                {
                    if (m.Position.X > fixtures[i].Body.Position.X && m.Position.X < fixtures[i].Body.Position.X + 100)
                    {
                        if (m.Position.Y > fixtures[i].Body.Position.Y  - 50 && m.Position.Y < fixtures[i].Body.Position.Y + 150)
                        {
                            score += 100;
                            fixtures[i].Body.ApplyForce(hitForce);
                        }
                    }
                }
            }
            prevM = m;
        }
    }
}
