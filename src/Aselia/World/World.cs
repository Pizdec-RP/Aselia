using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Aselia
{
	public class World
	{
		private readonly Player player;
        private Dictionary<Point, Chunk> chunks = new Dictionary<Point, Chunk>();

		public World()
		{
			player = new Player();
			//Microsoft.Xna.Framework.
        }

		public void Tick()
		{
			player.Tick();
		}

		public void Render()
		{
			player.Render();
            //рендер партиклов?
        }

        public void setBlock(int id, int x, int y) {
			getChunk(new Point(x, y)).setBlock(id, x >> 5, y >> 5);
		}

		public Chunk getChunk(Point chunkpos) {
			if (chunks.ContainsKey(chunkpos)) {
				return chunks[chunkpos];
			} else {
				Chunk c = new Chunk(chunkpos);
				//read from save
				c.Generate();
				chunks[chunkpos] = c;
				return c;
			}
		}

		public static Point ToChunkPos(float x, float y) {
			return new Point(((int)MathF.Floor(x)) >> 5, ((int)MathF.Floor(y)) >> 5);
		}
	}

	public class Chunk
	{
		private Texture2D model;
		private Point pos;                 //сжатые координаты
		private Boolean needUpdate = true;
		private Vector2 texturepos;        //левый нижний угол относительно координат мира
		private int[,] blocks;

		public Chunk(Point pos) {
			this.pos = pos;
			texturepos = new Vector2(pos.X << 5, pos.Y << 5);
			blocks = new int[32, 32];
		}

		private void updateModel() {
			//update
			needUpdate = false;
        }

		public void Render() {
			if (needUpdate) {
				updateModel();

                //рендер бекграунда
                //рендер мобов
				//рендер блоков
            }
        }

		public void Tick() {
			//протикивание живности
		}

		public void Generate() {
			for (float i = pos.X << 5; i < (pos.X << 5 + 32); i++) { // i = 0 - 32
				float columnHeight = MathF.Sin(i);
				float normHeight = columnHeight * 128;
				for (int j = 0; j < 32; j++) {
					if (((pos.Y << 5) + j) <= normHeight) {
						setBlock(1, ((int)i) % 32, j);
					}
				}
            }
		}

		public void setBlock(int id, int x, int y) {
			blocks[x,y]	= id;
            needUpdate = true;
        }
	}
}
