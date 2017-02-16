using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
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
        Fixture balloonFixture;
        List<Vector2> positions;
        List<Body> bodies;
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
            positions = new List<Vector2>();
            bodies = new List<Body>();
            fixtures = new List<Fixture>();
            rand = new Random();
            world = new World(new Vector2(0,-9.8f));
            score = 0;
            time = "";
            hitForce = new Vector2(0, 10000f);

            this.IsMouseVisible = true;

            balloonBody = new Body(world);
            balloonFixture = balloonBody.CreateFixture(new CircleShape(1f, 1));
            balloonBody.Position = new Vector2(0,0);
            balloonBody.BodyType = BodyType.Dynamic;

            positions.Add(balloonBody.Position);
            bodies.Add(balloonBody);
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
            world.Step(0.5f);

            time = gameTime.TotalGameTime.Minutes + "" + string.Format("{0:0.00}",(float)gameTime.TotalGameTime.TotalSeconds/100);

            timer += gameTime.ElapsedGameTime.Milliseconds;

            if (timer > 5000)
            {
                CreateBalloon();
                timer = 0;
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

        public void CreateBalloon()
        {
            balloonBody = new Body(world);
            balloonFixture = balloonBody.CreateFixture(new CircleShape(1f, 1));
            balloonBody.Position = new Vector2(rand.Next(0,500), rand.Next(0, 500));
            balloonBody.BodyType = BodyType.Dynamic;

            positions.Add(balloonBody.Position);
            bodies.Add(balloonBody);
            fixtures.Add(balloonFixture);

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
