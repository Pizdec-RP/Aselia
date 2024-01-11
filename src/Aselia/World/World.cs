namespace Aselia
{
	internal class World
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

	internal class Column
	{

	}

	internal class Chunk
	{

	}
}
