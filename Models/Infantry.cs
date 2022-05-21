using System;

namespace Abstraction.Models
{
	/// <summary>
	/// Lowest level human player character
	/// </summary>
	public class Infantry : Player
	{
		/// <summary>
		/// For new player creation
		/// </summary>
		public Infantry() { }

		/// <summary>
		/// for loading players from a file
		/// </summary>
		/// <param name="level"></param>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <param name="power"></param>
		public Infantry(int level, Guid id, string name, int power, string email)
		{
			Level = level;
			Id = id;
			Name = name;
			Power = power;
			Email = email;
		}

		public override void LevelUpDown(int up)
		{
			base.Power += up;
		}

		public string Email { get; set; }

		public delegate void Action();

		private Action _act;

		/// <summary>
		/// Here I'm implementing my delegate the
		/// way Jonathan Gollnick. His was way more 
		/// slick and gave me a better idea of how 
		/// I could use them in my game
		/// </summary>
		public Action Act { set => _act = value; }

		public void DoAction()
		{
			if (_act != null)
			{
				_act();
			}
		}
	}
}
