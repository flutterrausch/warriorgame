using System;
using System.Collections.Generic;

namespace warriorGame
{
	public static class RndSrc
	{
		// RND helpers
		// TODO improve Randomization etc, see Tim Coreys video  https://www.youtube.com/watch?v=kW84q8WOBdU
		
		private static readonly Random _rnd = new Random();


		private static int GetInt(int max)  // 0..max-1
		{
			return _rnd.Next(max);
		}

		public static void Test_GetInt()
		{
			for (int ii = 0; ii < 100; ++ii)
			{
				Console.WriteLine("GetInt = " + GetInt(5));
			}
		}

		public static double Vary(double baseVal, double plusMinusPercent, double maxVal)
		{
			// scatter around baseVal -> baseVal +/- rnd(percent)
			
			double diffMax = baseVal * plusMinusPercent/Const.MaxPercent;
			double rndVaried = baseVal - diffMax + (double) GetInt(Convert.ToInt32(2*diffMax));
			if (rndVaried > maxVal)
			{
				rndVaried = maxVal;
				//Console.WriteLine("MAX");
			}
			else if (rndVaried < 0)
			{
				rndVaried = 0d;
			}
				
			return rndVaried;
		}

		public static void Test_Vary(double baseVal, int plusMinusPercent, double maxVal)
		{
			for (int ii = 0; ii < 200; ++ii)
			{
				Console.WriteLine("Vary = " + Vary(baseVal, plusMinusPercent, maxVal));
			}
		}

		public static List<Species> PairFromList(ref List<Species> beings)
		{
			// Randomly choose and remove a pair of players from the list
			
			List<Species> pair = new List<Species>();  // TODO new necessary / difference?
			int rnd;
			
			// first pick
			rnd = RndSrc.GetInt(beings.Count);
			pair.Add(beings[rnd]);
			beings.RemoveAt(rnd);

			// second pick
			rnd = RndSrc.GetInt(beings.Count-1);
			pair.Add(beings[rnd]);
			beings.RemoveAt(rnd);

			return pair;
		}

		public static void Test_printList(List<Species> list)
		{
			foreach (Species species in list)
			{
				Console.WriteLine(species.name);
			}
			Console.WriteLine();
		}
	}
}