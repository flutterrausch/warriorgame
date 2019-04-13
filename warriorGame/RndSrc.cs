using System;
namespace warriorGame
{
	// TODO whole class static any useful? new Random in Constructor?
	public class RndSrc
	{
		private static Random _rnd = new Random();  // TODO Randomize?


		public static double GetRnd(int max)  // TODO property get
		{ 
			return _rnd.Next(max);
		}

		public static double RndVary(double baseVal, int plusMinusPercent, double maxVal)
		{
			double diffMax = baseVal * plusMinusPercent/100;
			double rndVaried = baseVal - diffMax + GetRnd(Convert.ToInt32(2*diffMax));  // base +/- rnd(percent)
			if (rndVaried > maxVal)
			{
				rndVaried = maxVal;
				//Console.WriteLine("MAX");
			}
			else if (rndVaried < 0)
			{
				rndVaried = 0f;
			}
				
			return rndVaried;
		}

	}
}
