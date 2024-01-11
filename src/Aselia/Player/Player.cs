using Aselia.src.Aselia.Vectors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Aselia.src.Aselia.Player {
    internal class Player {
        private Texture2D texture;
        private Vec2f pos = new Vec2f();

        public Player() {
            texture = GameInstance.instance.Content.Load<Texture2D>("player");
        }

        public void render() {
            GameInstance.instance.camera.render(texture, pos);
        }

        public void tick() {

        }
    }

    internal class Camera {
        public float camScale;
        public int width, height;
        public Vec2f pos;

        public Camera(float x, float y) {
            width = GameInstance.instance.graphics.PreferredBackBufferWidth;
            height = GameInstance.instance.graphics.PreferredBackBufferHeight;
            GameInstance.log(width+" "+height);
            pos = new Vec2f(x + width / 2, y + height / 2);
        }

        /*public void setPos(float x, float y) {
            pos.set(x - width / 2, y - height / 2);
        }*/

        public void render(Texture2D t, Vec2f tpos) {
            GameInstance.instance.batch.Draw(t, pos.substract(tpos).substractl(t.Width/2, t.Height).asXNAVector(), Color.White);
        }
    }
}
