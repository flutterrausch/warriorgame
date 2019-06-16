using System;
using System.Collections.Generic;
using static System.Environment;

namespace warriorGame
{
	public class GameLoop
	{
		//	1/ input
		//		. rnd-move-collide-decideIfFightOrMakeLove
		//	2/ update states
		//		- fight
		//			- health
		//		. recover-per-round
		//	3/ output
		//		. print

		private bool _gameOn = true;
		private uint round = 1;

		public void Start(ref List<Species> fighters)
		{
			while (_gameOn)
			{
				Console.WriteLine(NewLine + "GAME ROUND " + round);

				_gameOn &= Fight.FullFight(ref fighters);
				_gameOn &= (fighters.Count > 1);

				++round;
				//if (round > 100)  break;
			}

			Console.WriteLine(NewLine + "GAME OVER, " +
			                  Fight.GetSurvivedName(Fight.WhoSurvived(fighters)) +  // fighters = last pair TODO bissel heikel
			                  " is left." + NewLine);
		}
	}
}
