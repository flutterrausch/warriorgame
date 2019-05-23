using System;

namespace warriorGame
{
	public class Species
	{
		/// health
		public double health { get; set; }

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
				
		public double attackMax  // TODO protected?!
		{
			get { return _attackMax; }
			set { _attackMax = value; }
		}

		public double blockMax
		{
			get { return _blockMax; }
			set { _blockMax = value; }
		}
	}
}