using Blocks;
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
		private List<Point> renderingChunks = new List<Point>();

		public World()
		{
			player = new Player();
			renderingChunks.Add(new Point(0,-1));
			//Microsoft.Xna.Framework.
        }

		public void Tick()
		{
			player.Tick();
		}

		public void Render()
		{
			player.Render();
			foreach (Point p in renderingChunks) {
				getChunk(p).Render();
            }
            //рендер партиклов?
        }

        public void setBlock(int id, int x, int y)
		{
			getChunk(ToChunkPos(x, y)).setBlock(id, x >> 5, y >> 5);
		}

		public Chunk getChunk(Point chunkpos)
		{
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

		public static Point ToChunkPos(float x, float y)
		{
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

		public Chunk(Point pos)
		{
			this.pos = pos;
			texturepos = new Vector2(pos.X*256, pos.Y*256);
			blocks = new int[32, 32];
			model = GameInstance.Instance.Content.Load<Texture2D>("stone"); //чиста для теста
        }

		private void updateModel()
		{
            Texture2D rt = new Texture2D(GameInstance.Instance.GraphicsDevice, 256, 256);
            Color[] pixels = new Color[256*256];

            for (int i = 0; i < 32; i++) {
				for (int j = 0; j < 32; j++) {
					Texture2D texture = Block.blocks[blocks[i, j]].GetTexture();
                    Color[] overlayPixels = new Color[8*8];
                    texture.GetData(overlayPixels);

                    int startX = i*8;
                    int startY = j*8;

                    for (int y = 0; y < 8; y++) {
                        for (int x = 0; x < 8; x++) {
                            int baseIndex = (startY + y) * 256 + (startX + x);
                            int overlayIndex = y * 8 + x;

                            if (overlayPixels[overlayIndex].A != 0) {
                                pixels[baseIndex] = overlayPixels[overlayIndex];
                            }
                        }
                    }
                }
			}
			rt.SetData(pixels);
			model = rt;
        }

		public void Render()
		{
            if (needUpdate) {
				updateModel();
                needUpdate = false;
            }
            //рендер бекграунда
            //рендер мобов

            GameInstance.Instance.Camera.RenderTexture(model, texturepos.X, texturepos.Y, 32, 32);

            /*for (int i = 0; i < 32; i++) {
                for (int j = 0; j < 32; j++) {
                    GameInstance.Instance.Camera.RenderTexture(model, texturepos.X+i*8, texturepos.Y+j*8, 1, 1);
                }
            } ставлю этому коду 0 фпсов из 10 */
        }

        public void Tick()
		{
			//протикивание живности
		}

		public void Generate()
		{
			/*for (float i = pos.X << 5; i < (pos.X << 5 + 32); i++) {
				float columnHeight = MathF.Sin(i);
				float normHeight = columnHeight * 128;
				for (int j = 0; j < 32; j++) {
					if (((pos.Y << 5) + j) <= normHeight) {
						setBlock(1, ((int)i) % 32, j);
					}
				}
            }*/
			for (int i = 0; i < 32; i++) {
				for (int j = 0; j < 32; j++) {
                    setBlock(1, i, j);
                }
			}
		}

		public void setBlock(int id, int x, int y)
		{
			blocks[x,y]	= id;
            needUpdate = true;
        }
    }
}
