using Apos.Camera;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Aselia
{
	public class GameInstance : Game
	{
		public static GameInstance Instance { get; set; }

		
		public GraphicsDeviceManager Graphics { get; private set; }
		public SpriteBatch Batch { get; private set; }
		private World world;
		public Renderer Renderer;
		public IVirtualViewport defaultViewport;
        private SimpleFps fps = new SimpleFps();
        private SpriteFont font;
		private Vector2 fpsPos = new Vector2(10, 10);

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
            defaultViewport = new DefaultViewport(GraphicsDevice, Window);
            Renderer = new Renderer(0f, 0f);
            font = Content.Load<SpriteFont>("Underdog");
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

            //world.Tick(); нужен отдельный поток 50 тиков в секунду
            fps.Update(gameTime);
            base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			Batch.Begin();

			world.Render();

            fps.DrawFps(Batch, font, fpsPos, Color.White);

            Batch.End();
			base.Draw(gameTime);
		}

		public static void Log(String text)
		{
            Trace.WriteLine("[Log] " + text);
		}
	}

    public class SimpleFps {
        private double frames = 0;
        private double updates = 0;
        private double elapsed = 0;
        private double last = 0;
        private double now = 0;
        public double msgFrequency = 1.0f;
        public string msg = "";

        public void Update(GameTime gameTime) {
            now = gameTime.TotalGameTime.TotalSeconds;
            elapsed = (double)(now - last);
            if (elapsed > msgFrequency) {
                msg = " Fps: " + (frames / elapsed).ToString() + "\n Elapsed time: " + elapsed.ToString() + "\n Updates: " + updates.ToString() + "\n Frames: " + frames.ToString();
                //Console.WriteLine(msg);
                elapsed = 0;
                frames = 0;
                updates = 0;
                last = now;
            }
            updates++;
        }

        public void DrawFps(SpriteBatch spriteBatch, SpriteFont font, Vector2 fpsDisplayPosition, Color fpsTextColor) {
            spriteBatch.DrawString(font, msg, fpsDisplayPosition, fpsTextColor);
            frames++;
        }
    }
}
