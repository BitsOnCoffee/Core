using System;
using System.Collections.Generic;

namespace BitsOnCoffee.Core.Extensions
{
	public static class EnumExtensions
	{
		#region GetFlagValues
		/// <summary>
		/// Returns the collection of values from the enumeration marked with attribute System.Flags.
		/// </summary>
		/// <param name="input">Enum with values</param>
		/// <returns>Collection of enum values.</returns>
		public static IEnumerable<Enum> GetFlagValues(this Enum input)
		{
			foreach (Enum value in Enum.GetValues(input.GetType()))
			{
				if (input.HasFlag(value))
				{
					yield return value;
				}
			}
		} 
		#endregion
	}
}
