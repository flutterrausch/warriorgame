using System;

namespace warriorGame
{
	public class Species
	{
		/// misc
		public string name { get; }

		public Species(string _name)
		{
			name = _name;
			health = 100f;
		}

		public void Print()
		{
			Console.WriteLine("{0} attackM={1:0} blockM={2:0} health={3:0}", name, attackMax, blockMax, health);
		}

		
		/// health
		public double health { get; set; }  // TODO protected?! Fight class usage..

		public string getHealthBar()
		{
			const int total = 30;

			int count = (int) Math.Round(health * (double) total / 100d);
			string bar = "[" + new string('#', count);
			bar = bar.PadRight(total + 1) + "]";
            
			return bar;
		}

		
		/// fight
		private double _attackMax;
		private double _blockMax;
				
		public double attackMax
		{
			get { return _attackMax; }
			protected set { _attackMax = value; }
		}

		public double blockMax
		{
			get { return _blockMax; }
			protected set { _blockMax = value; }
		}
	}
}