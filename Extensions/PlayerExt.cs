using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Methods
{
	public static class PlayerExt
	{
		public static void PrintPlayerName(this Player player)
		{
			Console.WriteLine("__________ Players __________");
			Console.WriteLine($"Player Name: {player.Name}");
			Console.WriteLine();
		}
		public static void PrintPlayerStats(this Player player)
		{
			Console.WriteLine("__________ Player Stats __________");
			Console.WriteLine($"Player Name: {player.Name} Player Id: {player.Id} Player Power: {player.Power}");
			Console.WriteLine();
		}

		public static void PrintPlayerStats(this Bot player)
		{
			Console.WriteLine("__________ Bot Stats __________");
			Console.WriteLine($"Bot Name: {player.Name}");
			Console.WriteLine($"Bot Id: {player.Id}");
			Console.WriteLine($"Bot Power: {player.Power}");
			Console.WriteLine();
		}
	}
}
