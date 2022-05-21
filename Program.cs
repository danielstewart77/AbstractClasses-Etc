using System;
using Abstraction.Models;
using Abstraction.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Abstraction
{
	public class Program
	{
		static Infantry player1 = new Infantry();
		static List<Bot> bots = new List<Bot>();
		static int Main(string[] args)
		{

			// propt the user for the type of player creation
			var option = UserDialog();

			if (option == 1)
			{
				NewPlayer();
			}
			else if (option == 2)
			{
				LoadPlayer();
			}
			else { return 0; } // close app

			LoadBots();

			PrintConfirmation();

			bool play = true;
			do
			{
				play = PlayDialog();
			}
			while (play);

			if (SaveDialog()) SavePlayer();

			Console.WriteLine("Press any key to quit");
			Console.ReadKey();
			return 0;
		}

		public static int UserDialog()
		{
			int selection = 0;
			Console.WriteLine("Would you like to create a new user or load an existing user?");
			Console.WriteLine("Select 1 for new, select 2 for existing");
			try
			{
				selection = int.Parse(Console.ReadLine());

				if (selection != 1 && selection != 2) throw new Exception();

				// either let the user create a new player or load one
				return selection;
			}
			catch 
			{
				Console.WriteLine("You stink!");
				return 0;
			}
			
		}

		public static bool PlayDialog()
		{
			Console.WriteLine("Would you like to make a move? (y/n)");
			string option = Console.ReadLine();
			if (option.ToLower() != "y") return false;

			Console.WriteLine("Would you like to move or attack? (m/a)");
			option = Console.ReadLine();
			if (option.ToLower() != "m" && option.ToLower() != "a") return false;

			switch (option.ToLower())
			{
				// here's where the delegate is used:
				// the methods Move and Attack are passed
				// to the deligate Act
				case "m": player1.Act = Move;
					player1.DoAction();
					break;
				case "a": player1.Act = Attack;
					player1.DoAction();
					break;
			}

			Console.WriteLine("\n");

			return true;
		}

		/// <summary>
		/// This is one the methods being passed
		/// to the delegate defined in Infintry.cs
		/// ---------------------------------------
		/// Player move: Less risk to the player
		/// than an attack, less chance of power, 
		/// level up
		/// </summary>
		/// <param name="player1"></param>
		public static void Move()
		{
			int seed = Convert.ToInt32(DateTime.Now.Second);
			Random rand = new Random(seed);

			// randomly select a bot
			int whichBot = rand.Next(0,2);
			// get a random attack offset
			int botAttackOffset = rand.Next(-3, 0);
			
			int powerOfBotAttack = bots[whichBot].Power + botAttackOffset;
			// player gets a small power increase for moving
			int rewordForMoving = rand.Next(1, 3);

			player1.PowerUpDown(rewordForMoving);
			Console.WriteLine($"\n\n{player1.Name}, you have moved {rewordForMoving} and now have {player1.Power} power");
			Console.WriteLine($"{bots[whichBot].Name} has attacked you");
			Console.WriteLine($"The power of {bots[whichBot].Name} attack is {powerOfBotAttack}");
			
			player1.PowerUpDown(-powerOfBotAttack);

			Console.WriteLine($"You have {player1.Power} power remaining");

			// if a player's out of power, they get moved back a level 
			// and their power is restored
			if (player1.Power < 1)
			{
				player1.LevelUpDown(-1);
				player1.Power = 10;

				Console.WriteLine($"{player1.Name}, you have died");
				Console.WriteLine($" You been demoted to level {player1.Level}");
				Console.WriteLine($" Your power is {player1.Power}");
			}

			Console.WriteLine("\n\n\n");
		}

		/// <summary>
		/// This is one the methods being passed
		/// to the delegate defined in Infintry.cs
		/// ---------------------------------------
		/// Player move: More risk to the player
		/// than a move, more chance of power, 
		/// level up
		/// </summary>
		/// <param name="player1"></param>
		public static void Attack()
		{
			int seed = Convert.ToInt32(DateTime.Now.Second);
			Random rand = new Random(seed);

			// randomly select a bot
			int whichBot = rand.Next(0, 2);
			// get a defence attack offset
			int botDefenceOffset = rand.Next(-3, 3);

			// get a random attack offset
			int playerAttackOffset = rand.Next(-3, 3);

			int powerOfBotDefence = bots[whichBot].Power + botDefenceOffset;
			// player gets a larger point increase for attacking
			int rewordForAttacking = rand.Next(3, 5);

			player1.PowerUpDown(rewordForAttacking);
			Console.WriteLine($"\n\n{player1.Name}, you have flexed {rewordForAttacking} and now have {player1.Power} power");

			int powerOfAttack = rewordForAttacking + playerAttackOffset;

			Console.WriteLine($"You have attacked {bots[whichBot].Name} with {powerOfAttack} power\n");
			Console.WriteLine($"{bots[whichBot].Name} has defended with {powerOfBotDefence} power");

			player1.PowerUpDown(-powerOfBotDefence + rewordForAttacking);

			// check player power
			Console.WriteLine($"You now have {player1.Power} power\n");

			// bot sustains damage
			bots[whichBot].Power -= powerOfAttack;
			Console.WriteLine($"{bots[whichBot].Name} has sustained damage and now has {bots[whichBot].Power} power\n");

			// if a player's out of power, they get moved back a level 
			// and their power is restored
			if (player1.Power < 1)
			{
				player1.LevelUpDown(-1);
				player1.Power = 10;
			}

			// if player manages to kill a bot
			// they are reworded with +5 power
			// and the bot is respawned at full power
			if (bots[whichBot].Power < 1)
			{
				player1.Power += 5;
				bots[whichBot].Power = bots[whichBot].Level;

				Console.WriteLine($"Good job! You killed {bots[whichBot].Name}, but then he got better");
				Console.WriteLine($"+5 for you! You now have {player1.Power} power");
			}

			Console.WriteLine("\n\n\n");
		}

		public static bool SaveDialog()
		{
			Console.WriteLine("Would you like to save your player? (y/n)");
			string option = Console.ReadLine();
			if (option.ToLower() != "y" && option.ToLower() != "n") return false;
			return (option == "y");
		}

		public static void NewPlayer()
		{
			Console.WriteLine("What would you like to name your player?\n");
			// player creation
			var name = Console.ReadLine();

			Console.WriteLine("What's your email address?\n");
			// player creation
			var email = Console.ReadLine();

			player1 = new Infantry
			{
				Name = name,
				Email = email
			};
		}

		public static void LoadPlayer()
		{
			Console.WriteLine("Please enter the path to your player file");
			string filePath = Console.ReadLine();

			try
			{

				string jsonString = File.ReadAllText(filePath);
				player1 = JsonSerializer.Deserialize<Infantry>(jsonString);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void SavePlayer()
		{

			Console.WriteLine("Please enter the path to your player file");
			string filePath = Console.ReadLine();

			try
			{
				using (StreamWriter writetext = new StreamWriter("write.txt"))
				{
					string jsonString = JsonSerializer.Serialize(player1);
					File.WriteAllText(filePath, jsonString);
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		public static void LoadBots()
		{
			for (int i = 0; i < 3; i++)
			{
				bots.Add(new Bot(3));
			}
		}

		public static void PrintConfirmation()
		{
			Console.WriteLine("\n\n");
			//player1.PrintPlayerName();
			//foreach (Bot bot in bots) bot.PrintPlayerName();

			player1.PrintPlayerStats();
			bots.ForEach(b => b.PrintPlayerStats()); // built in method, using lambda
		}
	}
}
