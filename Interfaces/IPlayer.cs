using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Methods
{
	/// <summary>
	/// All player objects have Ids and Names
	/// </summary>
	internal interface IPlayer
	{
		Guid Id { get; }
		string Name { get; set; }
	}
}
