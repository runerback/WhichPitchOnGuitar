using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhichPitchOnGuitar
{
	/// <summary>
	/// Tunes of each string, from 6 to 1, up to down
	/// </summary>
	sealed class Tuning : IEquatable<Tuning>
	{
		public Tuning(IEnumerable<int> toneIndexSource, string name)
		{
			if (toneIndexSource == null)
				throw new ArgumentNullException("toneIndexSource");

			var toneIndex = this.toneIndex;
			using (var iterator = toneIndexSource.GetEnumerator())
			{
				for (int i = 0; i < Guitar.STRING_LEN; i++)
				{
					if (!iterator.MoveNext())
						throw new ArgumentException("toneIndexSource. Incompleted");
					int index = iterator.Current;
					if (index < 0 || index >= MusicalAlphabet.LEN)
						throw new ArgumentException(
							string.Format("toneIndexSource. invalid tone index at {0}", i));
					toneIndex[i] = index;
				}
				if (iterator.MoveNext())
					throw new ArgumentException("toneIndexSource. Too long");
			}
			this.BaseToneIndexes = toneIndex;
			this.BaseTones = toneIndex
				.Select(item => MusicalAlphabet.At(0, item))
				.ToArray();
			this.hashcode = checked(toneIndex
				.Select((_, i) => toneIndex.Take(i + 1).Sum() + i)
				.Sum());

			this.name = string.IsNullOrEmpty(name) ?
				string.Join(null, this.BaseTones) :
				name;
		}

		private readonly int[] toneIndex = new int[Guitar.STRING_LEN];
		public readonly IEnumerable<int> BaseToneIndexes;
		public readonly IEnumerable<string> BaseTones;

		private string name;
		public string Name
		{
			get { return this.name; }
		}

		public static readonly Tuning StandardE = new Tuning(new int[] { 7, 0, 5, 10, 2, 7 }, "StandardE");
		public static readonly Tuning OpenD = new Tuning(new int[] { 7, 0, 5, 10, 2, 10 }, "OpenD");

		public bool Equals(Tuning other)
		{
			if (other == null)
				return false;
			return hashcode == other.hashcode;
		}

		public static bool Equals(Tuning left, Tuning right)
		{
			return left == null ? right == null : left.Equals(right);
		}

		private int hashcode;
		public override int GetHashCode()
		{
			return hashcode;
		}
	}
}
