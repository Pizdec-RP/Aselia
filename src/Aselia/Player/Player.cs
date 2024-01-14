﻿using Entities;
using Microsoft.Xna.Framework.Graphics;
using System.Numerics;

namespace Aselia;
public class Player : Entity
{
	private Texture2D texture;

	public Player()
	{
		texture = GameInstance.Instance.Content.Load<Texture2D>("player");
	}

	public new void Render()
	{
		base.Render();
		GameInstance.Instance.Renderer.RenderEntity(texture, pos.X, pos.Y, 1.4f, 2.85f);
        GameInstance.Instance.Renderer.setPos(pos.X, pos.Y);
    }

	public new void Tick()
	{
        base.Tick();
		
	}
}

