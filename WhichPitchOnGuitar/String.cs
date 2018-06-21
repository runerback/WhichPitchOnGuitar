using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhichPitchOnGuitar
{
	sealed class String
	{
		public String(int baseToneIndex, int index)
		{
			if (index < 0)
				throw new ArgumentException("index. should not less than 0");
			if (index >= 6)
				throw new ArgumentException("index. a normal guitar can have 6 strings most");

			SetBaseToneIndex(baseToneIndex);
			this.index = index;
		}

		public String(int index) : this(0, index) { }

		private int baseToneIndex;
		public int BaseToneIndex
		{
			get { return this.baseToneIndex; }
		}

		public void SetBaseToneIndex(int value)
		{
			if (value != this.baseToneIndex)
			{
				if (value < 0)
					throw new ArgumentException("baseToneIndex. should not less than 0");
				if (value >= MusicalAlphabet.LEN)
					throw new ArgumentException("baseToneIndex. too large");
				this.baseToneIndex = value;
			}
		}

		private int index;
		public int Index
		{
			get { return this.index; }
		}

		public override string ToString()
		{
			return "String " + (index + 1);
		}
	}
}
