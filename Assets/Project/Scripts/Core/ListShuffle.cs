using System;
using System.Collections.Generic;

namespace GEM.Core
{
    /// <summary>
    /// A utility class that contains an extension method to shuffle lists.
    /// </summary>
	public static class ListShuffle
	{
		private static readonly Random rng = new Random();

		/// <summary>
		/// Shuffles the specified list.
		/// </summary>
		/// <param name="list">The list to shuffle.</param>
		/// <typeparam name="T">Generic type argument.</typeparam>
		public static void Shuffle<T>(this IList<T> list)
		{
			var n = list.Count;
			while (n > 1)
			{
				n--;
				var k = rng.Next(n + 1);
				var value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
	}
}