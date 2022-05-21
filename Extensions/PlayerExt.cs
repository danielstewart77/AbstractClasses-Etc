using System;
using Abstraction.Models;

namespace Abstraction.Extensions
{
	public static class PlayerExt
	{
		public static void PrintPlayerName(this Player player)
		{
			Console.WriteLine("__________ Players __________");
			Console.WriteLine($"Player Name: {player.Name}");
			Console.WriteLine();
		}
		public static void PrintPlayerStats(this Infantry player)
		{
			Console.WriteLine("__________ Player __________");
			Console.WriteLine($"Player Name: {player.Name} Player Id: {player.Id} Player Email: {player.Email}");
			Console.WriteLine("__________ Player Stats __________");
			Console.WriteLine($"Player Power: {player.Power} Player Level: {player.Level}");
			Console.WriteLine();
		}

		public static void PrintPlayerStats(this Bot player)
		{
			Console.WriteLine("__________ Bot Stats __________");
			Console.WriteLine($"Bot Name: {player.Name}");
			Console.WriteLine($"Bot Id: {player.Id}");
			Console.WriteLine($"Bot Power: {player.Power}");
			Console.WriteLine($"Bot Level: {player.Level}");
			Console.WriteLine();
		}
	}
}
