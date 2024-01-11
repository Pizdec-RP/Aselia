using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Aselia.src.Aselia.World;
using Aselia.src.Aselia.Player;
using System.ComponentModel;

namespace Aselia.src.Aselia {
    internal class GameInstance : Game {
        public static GameInstance instance;
        public GraphicsDeviceManager graphics;
        public SpriteBatch batch;
        private World.World world;
        public Camera camera;

        public GameInstance() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            GameInstance.instance = this;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            world = new World.World();
            camera = new Camera(0f, 0f);
            base.Initialize();
        }

        protected override void LoadContent() {
            batch = new SpriteBatch(GraphicsDevice);

            
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            world.tick();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            batch.Begin();

            world.render();

            batch.End();
            base.Draw(gameTime);
        }

        public static void log(String text) {
            System.Diagnostics.Debug.WriteLine("[Log] "+text);
        }
    }
}
