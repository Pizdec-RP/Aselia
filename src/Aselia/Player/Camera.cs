
using Apos.Camera;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aselia;

public sealed class Renderer
{
    public Camera camera;
    private Rectangle r = new Rectangle();

    public Renderer(float x, float y)
	{
        camera = new Camera(GameInstance.Instance.defaultViewport);
        setPos(x, y);
    }

	public void setPos(float x, float y)
    {
        //int width = GameInstance.Instance.defaultViewport.Width;
        //int height = GameInstance.Instance.defaultViewport.Height;
        //GameInstance.Log(width + " " + height);
        camera.X = x;
        camera.Y = y;
        camera.Scale = new Vector2(10, 50);
        camera.Z = 10;
    }

	public void RenderEntity(Texture2D t, float x, float y, float width, float height)
	{
        r.Width = (int)width;
        r.X = (int) (camera.X - x) - (r.Width / 2);
        r.Height = (int)height;
        r.Y = (int)	(camera.Y - y) - r.Height;

		GameInstance.Instance.Batch.Draw(t, r, Color.White);
    }

    public void RenderTexture(Texture2D t, float x, float y, float width, float height)
    {
        r.Width = (int)width;
        r.X = (int)(camera.X - x);
        r.Height = (int)height;
        r.Y = (int)(camera.Y - y) - r.Height;

        GameInstance.Instance.Batch.Draw(t, r, Color.White);
    }
}

