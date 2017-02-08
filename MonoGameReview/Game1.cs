using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameReview
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D harambeTexture;
        Vector2 harambePosition;
        SpriteFont font;
        Vector2 fontPosition;
        Vector2 coordPosition;

        int speed = 100;

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
            harambePosition = new Vector2(250, 150);
            fontPosition = new Vector2(300, 100);
            coordPosition = new Vector2(700, 10);
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
            harambeTexture = Content.Load<Texture2D>("harambe");
            font = Content.Load<SpriteFont>("Font");
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
            ProcessInput();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MediumOrchid);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(harambeTexture, harambePosition, Color.White);
            spriteBatch.DrawString(font, "RIP HARAMBE", fontPosition, Color.White);
            spriteBatch.DrawString(font, "X: " + harambePosition.X + " Y: " + harambePosition.Y, coordPosition, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void ProcessInput()
        {
            KeyboardState kb = Keyboard.GetState();
            if(kb.IsKeyDown(Keys.W))
            {
                harambePosition.Y-= speed;
            }
            if (kb.IsKeyDown(Keys.A))
            {
                harambePosition.X-= speed;
            }
            if (kb.IsKeyDown(Keys.S))
            {
                harambePosition.Y+= speed;
            }
            if (kb.IsKeyDown(Keys.D))
            {
                harambePosition.X+= speed;
            }

            //Screen Wrap
            if (harambePosition.X > graphics.PreferredBackBufferWidth)
            {
                harambePosition.X = 0;
            }
            if (harambePosition.X < 0)
            {
                harambePosition.X = graphics.PreferredBackBufferWidth;
            }
            if (harambePosition.Y > GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height)
            {
                harambePosition.Y = 0;
            }
            if (harambePosition.Y < 0)
            {
                harambePosition.Y = graphics.PreferredBackBufferHeight;
            }

        }
    }
}
