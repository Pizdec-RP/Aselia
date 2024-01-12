using Aselia;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocks {
    internal class Block {
        public static Dictionary<int, Block> blocks = new Dictionary<int, Block>() {
            {0, new Air(0,0)},
            {1, new Stone(0,0)},
        };

        public int X { get; set; }
        public int Y { get; set; }

        public Block(int x, int y) 
        {
            this.X = x; this.Y = y;
        }

        public virtual Texture2D GetTexture() { return null; }
        public virtual Rectangle GetBoundingBox() { return new Rectangle(); }
        public virtual Block Clone(int x, int y) { return null; }
        public virtual Boolean isRenderable() { return true; }
    }

    class Air : Block {
        public Air(int x, int y) : base(x, y)
        {
            
        }

        public override Texture2D GetTexture()
        {
            return null;
        }

        public override Rectangle GetBoundingBox()
        {
            return new Rectangle(this.X, this.Y, this.X+1, this.Y+1);
        }

        public override Air Clone(int x, int y)
        {
            return new Air(x, y);
        }

        public override Boolean isRenderable()
        { 
            return false;
        }
    }

    class Stone : Block {
        public Stone(int x, int y) : base(x, y)
        {

        }
        
        private static Texture2D Texture;
        public override Texture2D GetTexture()
        {
            if (Texture == null) Texture = GameInstance.Instance.Content.Load<Texture2D>("stone");
            return Texture;
        }

        public override Rectangle GetBoundingBox()
        {
            return new Rectangle(this.X, this.Y, this.X + 1, this.Y + 1);
        }

        public override Stone Clone(int x, int y)
        {
            return new Stone(x, y);
        }
    }
}
