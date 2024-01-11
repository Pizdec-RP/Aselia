using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aselia;

public sealed class Camera
{
	public float camScale;
	public int width, height;
	public Vec2f pos;

	public Camera(float x, float y)
	{
		width = GameInstance.Instance.graphics.PreferredBackBufferWidth;
		height = GameInstance.Instance.graphics.PreferredBackBufferHeight;
		GameInstance.Log(width + " " + height);
		pos = new Vec2f(x + width / 2, y + height / 2);
	}

	/*public void setPos(float x, float y) {
		pos.set(x - width / 2, y - height / 2);
	}*/

	public void Render(Texture2D t, Vec2f tpos)
	{
		GameInstance.Instance.batch.Draw(t, pos.substract(tpos).substractl(t.Width / 2, t.Height).asXNAVector(), Color.White);
	}
}

