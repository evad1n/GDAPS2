using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DynamicTreeCreation_Starter
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		// Random numbers
		Random rand;

		// The three trees
		Tree treeRed;
		Tree treeGreen;
		Tree treeBlue;

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

			// Create a 1x1 white texture - basically a pixel
			Texture2D pixel = new Texture2D(GraphicsDevice, 1, 1);
			pixel.SetData<Color>(new Color[] { Color.White });

			// Make a random number generator
			rand = new Random();

			// Create the three trees
			treeRed = new Tree(spriteBatch, pixel, Color.Red);
			treeGreen = new Tree(spriteBatch, pixel, Color.Green);
			treeBlue = new Tree(spriteBatch, pixel, Color.DodgerBlue);

			// Insert initial data into the trees
			for (int i = 0; i < 100; i++)
			{
				treeRed.Insert(rand.Next(0, 10000));
				treeGreen.Insert(i);
				treeBlue.Insert(rand.Next(0, 10));
			}
		}


		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				this.Exit();

			// After you have the rest of the assignment working:
			//  What happens if you insert a new piece of 
			//  data into the trees each frame?

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			// Draw the trees
			treeRed.Draw(new Vector2(200, 400));
			treeGreen.Draw(new Vector2(400, 400));
			treeBlue.Draw(new Vector2(600, 400));

			base.Draw(gameTime);
		}
	}
}
