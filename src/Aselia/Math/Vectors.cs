using Microsoft.Xna.Framework;

namespace Aselia.Math;
internal class Vec2f
{
	private static Vector2 template = new Vector2(0, 0);
	public float x, y;

	public Vec2f(float x, float y)
	{
		this.x = x;
		this.y = y;
	}

	public Vec2f()
	{
		x = 0.0f;
		y = 0.0f;
	}

	public Vec2f add(Vec2f other)
	{
		return new Vec2f(x + other.x, y + other.y);
	}

	public Vec2f add(float x, float y)
	{
		return new Vec2f(this.x + x, y + this.y);
	}

	public Vec2f addl(float x, float y)
	{
		this.x += x;
		this.y += y;
		return this;
	}

	public Vec2f substract(Vec2f other)
	{
		return new Vec2f(x - other.x, y - other.y);
	}

	public Vec2f substract(float x, float y)
	{
		return new Vec2f(this.x - x, this.y - y);
	}

	public Vec2f substractl(float x, float y)
	{
		this.x -= x;
		this.y -= y;
		return this;
	}


	public float sqrt(Vec2f other)
	{
		return MathU.fastSqrt(MathU.Pow(x - other.x, 2) + MathU.Pow(y - other.y, 2));
	}

	public Vector2 asXNAVector()
	{
		template.X = x;
		template.Y = y;
		return template;
	}

	internal void set(float x, float y)
	{
		this.x = x; this.y = y;
	}
}

