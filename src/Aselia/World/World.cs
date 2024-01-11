namespace Aselia
{
	public class World
	{


		private readonly Player player;

		public World()
		{
			player = new Player();
		}

		public void Tick()
		{
			player.Tick();
		}

		public void Render()
		{
			player.Render();
		}
	}

	public class Column
	{

	}

	public class Chunk
	{

	}
}
