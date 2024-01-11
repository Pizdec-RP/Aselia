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
		GameInstance.Instance.Camera.Render(texture, pos);
	}

	public void Tick()
	{

	}
}

