using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhichPitchOnGuitar
{
	class MusicalAlphabet : IEnumerable<string>
	{
		public const int LEN = 12;
		private static readonly string[] alphabets =
			Enumerable.Range(65, 7)
			.SelectMany(getAlphabets)
			.ToArray();

		private static IEnumerable<string> getAlphabets(int c, int index)
		{
			yield return ((char)c).ToString();
			if (index % 3 != 1)
				yield return (char)c + "#";
		}

		public IEnumerator<string> GetEnumerator()
		{
			return alphabets.AsEnumerable().GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public static string At(int startIndex, int distance)
		{
			if (startIndex < 0 || startIndex >= LEN)
				throw new ArgumentOutOfRangeException("startIndex");
			if (distance < 0)
				throw new ArgumentException("distance");
			return alphabets.ElementAt((startIndex + distance) % LEN);
		}
	}
}
