
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aselia;

public sealed class Camera
{
	public float camScale = 10;
	public int width, height;
	public Vector2 position;
    private static Rectangle r = new Rectangle();

	public Camera(float x, float y)
	{
		width = GameInstance.Instance.Graphics.PreferredBackBufferWidth;
		height = GameInstance.Instance.Graphics.PreferredBackBufferHeight;
		//GameInstance.Log(width + " " + height);
		position = new Vector2(x + width / 2, y + height / 2);
    }

	public void setPos(float x, float y)
    {
		position.X = x + width / 2;
        position.Y = y + height / 2;
    }

	public void RenderEntity(Texture2D t, float x, float y, float width, float height)
	{
        r.Width = (int)(width * camScale);
        r.X = (int) (position.X - x) - (r.Width / 2);
        r.Height = (int)(height * camScale);
        r.Y = (int)	(position.Y - y) - r.Height;

		GameInstance.Instance.Batch.Draw(t, r, Color.White);
    }

    public void RenderTexture(Texture2D t, float x, float y, float width, float height)
    {
        r.Width = (int)(width * camScale);
        r.X = (int)(position.X - x);
        r.Height = (int)(height * camScale);
        r.Y = (int)(position.Y - y) - r.Height;

        GameInstance.Instance.Batch.Draw(t, r, Color.White);
    }
}

