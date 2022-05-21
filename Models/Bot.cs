
namespace Abstraction.Models
{
	/// <summary>
	/// This class creates a Bot for a given level
	/// </summary>
	public class Bot : Player
	{
		private readonly string _name;

		/// <summary>
		/// A Bot's power is based on it's level
		/// </summary>
		/// <param name="level"></param>
		public Bot(int level) 
		{ 
			_name = $"Karen-{base.Id.ToString().Substring(0, 5)}";
			Power = level;
		}

		/// <summary>
		/// Bots are automatically given a name based on their Ids
		/// </summary>
		public override string Name { get => _name; }

		/// <summary>
		/// Bots power is based on its level
		/// </summary>
		public override int Power { get; set; }

		/// <summary>
		/// Bots level up based on the level clock.
		/// As the players spend more time in the level, the bots level => power increases
		/// </summary>
		/// <param name="timeOffest"></param>
		public override void LevelUpDown(int timeOffest)
		{
			Level += timeOffest;
		}
	}
}
