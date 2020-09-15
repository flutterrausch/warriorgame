using System;

namespace warriorGame
{
	public class Species
	{
		/// misc
		public string Name { get; }

		protected Species(string nameArg)
		{
			Name = nameArg;
			Health = Const.MaxPercent;
		}

		public void Print()
		{
			Console.WriteLine("{0} attackM={1:0} blockM={2:0} health={3:0}", Name, AttackMax, BlockMax, Health);
		}

		
		/// health - property + helper
		public double  Health { get; set; }  // TODO protected?! Fight class usage..

		public string getHealthBar()
		{
			// return a health bar string
			int count = (int) Math.Round(Health * (double) Const.HealthBarSize / Const.MaxPercent);
			string bar = "[" + new string('#', count);
			bar = bar.PadRight(Const.HealthBarSize + 1) + "]";
            
			return bar;
		}

		
		/// fight - AttackMax + AttackMax properties 
		private double _attackMax;
		private double _blockMax;
				
		public double AttackMax
		{
			get { return _attackMax; }
			protected set { _attackMax = value; }
		}

		public double BlockMax
		{
			get { return _blockMax; }
			protected set { _blockMax = value; }
		}
	}
}