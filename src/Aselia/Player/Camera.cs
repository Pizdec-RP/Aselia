
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
        int width = GameInstance.Instance.defaultViewport.Width;
        int height = GameInstance.Instance.defaultViewport.Height;
        //GameInstance.Log(width + " " + height);
        Vector2 v = camera.ScreenToWorld(width/2, height/2);
        //GameInstance.Log(v.ToString());
        camera.XY = new Vector2(x + v.X, y + v.Y);
    }

	public void RenderEntity(Texture2D t, float x, float y, float width, float height)
	{
        /*r.Width = (int)width;
        r.X = (int) (camera.X - x) - (r.Width / 2);
        r.Height = (int)height;
        r.Y = (int)	(camera.Y - y) - r.Height;*/
        Vector2 v = camera.WorldToScreen(x, y);
        //GameInstance.Log(v.ToString());

        GameInstance.Instance.Batch.Draw(t, v, Color.White);
    }

    public void RenderTexture(Texture2D t, float x, float y, float width, float height)
    {
        Vector2 v = camera.WorldToScreen(x, y);
        Vector2 v1 = camera.WorldToScreen(width, height);
        r.Width = (int)v1.X;
        r.X = (int)v.X;
        r.Height = (int)v1.Y;
        r.Y = (int)v.Y;
        
        GameInstance.Instance.Batch.Draw(t, r, Color.White);
    }
}

