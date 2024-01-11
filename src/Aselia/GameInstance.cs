using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Aselia
{
	public class GameInstance : Game
	{
		public static GameInstance Instance { get; set; }

		
		public GraphicsDeviceManager Graphics { get; private set; }
		public SpriteBatch Batch { get; private set; }
		private World world;
		public Camera Camera;

		public GameInstance()
		{

			Graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;		
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			world = new World();
			Camera = new Camera(0f, 0f);
			base.Initialize();
		}

		protected override void LoadContent()
		{
			Batch = new SpriteBatch(GraphicsDevice);


		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			world.Tick();

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			Batch.Begin();

			world.Render();

			Batch.End();
			base.Draw(gameTime);
		}

		public static void Log(String text)
		{
			System.Diagnostics.Debug.WriteLine("[Log] " + text);
		}
	}
}
