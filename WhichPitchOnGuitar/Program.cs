using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhichPitchOnGuitar
{
	class Program
	{
		static void Main()
		{
			Guitar guitar = new Guitar();

			for (int stringIndex = 1; stringIndex <= Guitar.STRING_LEN; stringIndex++)
			{
				for (int fretIndex = 0; fretIndex < 12; fretIndex++)
				{
					Console.WriteLine("Tune at {0} and Fret {1} on a {2} tuning guitar is {3}",
						guitar.StringAt(stringIndex),
						fretIndex,
						guitar.Tuning.Name,
						guitar.GetTuneAt(stringIndex, fretIndex));
				}
			}
			Console.ReadLine();
		}
	}
}
