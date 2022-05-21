using System;

namespace Abstraction.Interfaces
{
	/// <summary>
	/// All player objects have Ids, Names and Levels
	/// </summary>
	internal interface IPlayer
	{
		Guid Id { get; set; }
		string Name { get; set; }
		int Level { get; set; }
	}
}
