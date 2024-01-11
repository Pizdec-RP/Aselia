using Aselia;
using System;

public class Program
{
	[STAThread]
	public static void Main(string[] args)
	{
		var game = new GameInstance();

		GameInstance.Instance = game;
		game.Run();
	}
}
