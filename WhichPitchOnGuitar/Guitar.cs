using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhichPitchOnGuitar
{
	sealed class Guitar
	{
		/// <summary>
		/// this guitar only have 6 strings
		/// </summary>
		public const int STRING_LEN = 6;

		/// <summary>
		/// this guitar only have 24 frets
		/// </summary>
		public const int FRET_LEN = 24;

		public Guitar()
		{
			ApplyTuning(Tuning.StandardE);
		}

		private Tuning tuning;
		public Tuning Tuning
		{
			get { return this.tuning; }
		}

		/// <summary>
		/// from up to down
		/// </summary>
		private readonly String[] Strings = Enumerable.Range(1, STRING_LEN)
			.Select(item => new String(STRING_LEN - item))
			.ToArray();

		/// <summary>
		/// stringIndex start from 1 and from down to up on guitar
		/// </summary>
		public String StringAt(int stringIndex)
		{
			if (stringIndex < 1 || stringIndex > STRING_LEN)
				throw new ArgumentException("stringIndex. no string at specified index");
			return this.Strings[STRING_LEN - stringIndex];
		}

		public void ApplyTuning(Tuning tuning)
		{
			if (tuning == null)
				throw new ArgumentNullException("tuning");

			if (!Tuning.Equals(tuning, this.tuning))
			{
				this.tuning = tuning;

				using(var tuneIndexIterator = tuning.BaseToneIndexes.GetEnumerator())
				using (var stringIterator = Strings.AsEnumerable().GetEnumerator())
				{
					while (tuneIndexIterator.MoveNext() &
						stringIterator.MoveNext())
					{
						stringIterator.Current.SetBaseToneIndex(tuneIndexIterator.Current);
					}
				}
			}
		}

		/// <summary>
		/// stringIndex start from 1 and from down to up on guitar
		/// </summary>
		public string GetTuneAt(int stringIndex, int fretIndex)
		{
			if (stringIndex < 1 || stringIndex > STRING_LEN)
				throw new ArgumentException("stringIndex. no string at specified index");
			if (fretIndex < 0 || fretIndex >= FRET_LEN)
				throw new ArgumentException("fretIndex. too small or too large");

			return MusicalAlphabet.At(
				StringAt(stringIndex).BaseToneIndex,
				fretIndex);
		}
	}
}
