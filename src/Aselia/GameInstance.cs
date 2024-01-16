using Apos.Camera;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using System;
using System.Diagnostics;

namespace Aselia
{
	public class GameInstance : Game
	{
		public static GameInstance Instance { get; set; }
		public GraphicsDeviceManager Graphics { get; private set; }
		public SpriteBatch Batch { get; private set; }
        public Camera camera;
        public IVirtualViewport defaultViewport;
        private SimpleFps fps = new SimpleFps();
        private SpriteFont font;
        private Vector2 fpsPos;

        public GameInstance()
		{
			Graphics = new GraphicsDeviceManager(this);
            Graphics.PreferredBackBufferWidth = 1280;
            Graphics.PreferredBackBufferHeight = 720;
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
            defaultViewport = new DefaultViewport(GraphicsDevice, Window);
            font = Content.Load<SpriteFont>("Underdog");
            base.Initialize();
            camera = new Camera(GameInstance.Instance.defaultViewport);
            int width = GameInstance.Instance.defaultViewport.Width;
            int height = GameInstance.Instance.defaultViewport.Height;
            //GameInstance.Log(width + " " + height);
            Vector2 v = camera.ScreenToWorld(width / 2, height / 2);
            //GameInstance.Log(v.ToString());
            camera.XY = new Vector2(v.X, v.Y);//камера на 0 0

            fpsPos = camera.ScreenToWorld(10, 10);
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
			Batch.Begin(transformMatrix: camera.View);

            Texture2D t = GameInstance.Instance.Content.Load<Texture2D>("stone");

            Vector2 pos = camera.WorldToScreen(0,0);
            Vector2 size = camera.WorldToScreen(10,10);

            Batch.Draw(t, new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y), Color.White);

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
