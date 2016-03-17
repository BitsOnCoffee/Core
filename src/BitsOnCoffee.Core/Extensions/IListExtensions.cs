using System;
using System.Collections.Generic;

namespace BitsOnCoffee.Core.Extensions
{
	public static class IListExtensions
	{
		#region AddIfNotContains
		/// <summary>
		/// Adds item into the collection if the collection does not already contains the item.
		/// </summary>
		/// <typeparam name="TSource">Type of the items stored in the collection</typeparam>
		/// <param name="list">Collection into which the item would be added</param>
		/// <param name="item">Item to be added</param>
		public static void AddIfNotContains<TSource>(this IList<TSource> list, TSource item)
		{
			if (!list.Contains(item))
			{
				list.Add(item);
			}
		} 
		#endregion

		#region Shuffle
		/// <summary>
		/// Shuffles randomly the items in the collection.
		/// </summary>
		/// <typeparam name="TSource">Type of the items stored in the collection</typeparam>
		/// <param name="list">List to be shuffled</param>
		public static void Shuffle<TSource>(this IList<TSource> list)
		{
			Random rng = new Random();
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				TSource value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		} 
		#endregion
	}
}
