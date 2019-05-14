using System;

namespace warriorGame
{
	public static class RndSrc
	{
		private static readonly Random _rnd = new Random();  // TODO Randomize/Constructor?


		private static double GetRnd(int max)
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