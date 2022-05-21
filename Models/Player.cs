using System;
using Abstraction.Interfaces;

namespace Abstraction.Models
{
	/// <summary>
	/// Base player model used for players & bots
	/// </summary>
	public abstract class Player : IPlayer
	{
		private int _level;

		private Guid _id;

		public Player()
		{
			_id = Guid.NewGuid();
			_level = 1;
		}
		public Guid Id { get { return _id; } set { _id = value; } }

		/// <summary>
		/// players can have empty names, bots should not
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// regular players start at power 1, bots are based on their level
		/// </summary>
		public virtual int Power { get; set; } = 10;

		/// <summary>
		/// All players start at level 1, bots level increases during the level
		/// </summary>
		public int Level { get { return _level; } set { _level = value; } }

		public abstract void LevelUpDown(int up);

		public void PowerUpDown(int pow)
		{
			Power += pow;
		}
	}
}
