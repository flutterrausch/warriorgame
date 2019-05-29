using System;
using System.Collections.Generic;

namespace warriorGame
{
	public class RndSrc  // TODO static members?
	{
		private static readonly Random _rnd = new Random();  // TODO Randomize/Constructor?


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

		public static double Vary(double baseVal, int plusMinusPercent, double maxVal)
		{
			// TODO not formula, base percentage differences on max, IAmTimCorey RND video
			double diffMax = baseVal * plusMinusPercent/100;
			double rndVaried = baseVal - diffMax + (double) GetInt(Convert.ToInt32(2*diffMax));  // base +/- rnd(percent)
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
			List<Species> pair = new List<Species>();  // TODO new necessary / difference?
			int rnd;
			
			rnd = RndSrc.GetInt(beings.Count);
			pair.Add(beings[rnd]);
			beings.RemoveAt(rnd);

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