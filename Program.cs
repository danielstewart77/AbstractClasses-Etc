using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Methods
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Player player1 = new Player();
			player1.Name = "Daniel";

			Bot bot1 = new Bot(3);

			player1.PrintPlayerName();
			bot1.PrintPlayerName();

			player1.PrintPlayerStats();
			bot1.PrintPlayerStats();

			Console.ReadKey();		}
	}
}
