
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aselia;

public sealed class Camera
{
	public float camScale;
	public int width, height;
	public Vector2 position;

	public Camera(float x, float y)
	{
		width = GameInstance.Instance.Graphics.PreferredBackBufferWidth;
		height = GameInstance.Instance.Graphics.PreferredBackBufferHeight;


		GameInstance.Log(width + " " + height);


		position = new Vector2(x + width / 2, y + height / 2);
		

	}

	/*public void setPos(float x, float y) {
		pos.set(x - width / 2, y - height / 2);
	}*/

	public void Render(Texture2D t, Vector2 tpos)
	{
		

		var pos = (position - tpos) - new Vector2(t.Width / 2, t.Height);

		GameInstance.Instance.Batch.Draw(t, pos, Color.White);
	}
}

