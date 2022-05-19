using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Methods
{
	/// <summary>
	/// This class creates a Bot for a given level
	/// </summary>
	public class Bot : Player
	{
		private readonly int _level;
		/// <summary>
		/// A Bot's power is based on it's level
		/// </summary>
		/// <param name="level"></param>
		public Bot(int level) 
		{ 
			_level = level;
		}

		/// <summary>
		/// Bots are automatically given a name based on their Ids
		/// </summary>
		public override string Name { get => $"Karen-{base.Id.ToString().Substring(0, 5)}"; }

		public override int Power { get => _level; }
	}
}
