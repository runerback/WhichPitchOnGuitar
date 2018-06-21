using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhichPitchOnGuitar
{
	sealed class Fret
	{
		public Fret(int index)
		{
			if (index < 0)
				throw new ArgumentException("index. should not less than 0");
			if (index > 24)
				throw new ArgumentException("index. too large for a human guitar player");
			this.index = index;
		}

		private int index;
		public int Index
		{
			get { return this.index; }
		}
	}
}
