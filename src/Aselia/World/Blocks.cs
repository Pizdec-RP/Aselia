﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocks {
    internal class Block {
        public static Dictionary<int, Block> blocks = new Dictionary<int, Block>() {
            {0, new Air(0,0)}
        };

        public int X { get; set; }
        public int Y { get; set; }

        public Block(int x, int y) 
        {
            this.X = x; this.Y = y;
        }

        public Texture2D GetTexture() { return null; }
        public Rectangle GetBoundingBox() { return new Rectangle(); }
        public Block Clone(int x, int y) { return null; }
    }

    class Air : Block {
        public Air(int x, int y) : base(x, y)
        {
            
        }

        public new Texture2D GetTexture()
        {
            return null;
        }

        public new Rectangle GetBoundingBox()
        {
            return new Rectangle(this.X, this.Y, this.X+1, this.Y+1);
        }

        public new Air Clone(int x, int y)
        {
            return new Air(x, y);
        }
    }

    class Stone : Block {
        public Stone(int x, int y) : base(x, y)
        {

        }

        public new Texture2D GetTexture()
        {
            return null;
        }

        public new Rectangle GetBoundingBox()
        {
            return new Rectangle(this.X, this.Y, this.X + 1, this.Y + 1);
        }

        public new Stone Clone(int x, int y)
        {
            return new Stone(x, y);
        }
    }
}
