using Microsoft.Xna.Framework.Graphics;

namespace Aselia;
internal class Player
{
	private Texture2D texture;
	private Vec2f pos = new Vec2f();

	public Player()
	{
		texture = GameInstance.Instance.Content.Load<Texture2D>("player");
	}

	public void Render()
	{
		GameInstance.Instance.Camera.Render(texture, pos);
	}

	public void Tick()
	{

	}
}

