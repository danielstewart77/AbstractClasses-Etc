using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Methods
{
	/// <summary>
	/// Base player model used for players & bots
	/// </summary>
	public class Player : IPlayer
	{
		public Guid Id => Guid.NewGuid();

		/// <summary>
		/// players can have empty names, bots should not
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// regular players start at power 1
		/// </summary>
		public virtual int Power { get; set; } = 1;
	}
}
