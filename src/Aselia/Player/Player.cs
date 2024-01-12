using Microsoft.Xna.Framework.Graphics;
using System.Numerics;

namespace Aselia;
public class Player
{
	private Texture2D texture;
	private Vector2 pos = new Vector2();

	public Player()
	{
		texture = GameInstance.Instance.Content.Load<Texture2D>("player");
	}

	public void Render()
	{
		GameInstance.Instance.Camera.RenderEntity(texture, pos.X, pos.Y, 0.9f, 1.8f);
	}

	public void Tick()
	{
		//pos.Y -= 0.1f;
	}
}

