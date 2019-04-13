using System;
using System.Collections.Generic;

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


		public void Start(List<IFightable> fighters)
		{
			Fight.FightersPrint(fighters);

			uint round = 1;
			while (_gameOn)
			{
				Console.WriteLine(Environment.NewLine + "round " + round);
				_gameOn &= Fight.FightRound(fighters);
				//_gameOn &= Health.RecoverRound(fighters);

				if (++round > 100)  break;
			}

			Console.WriteLine(Environment.NewLine + "Game Over, " + Fight.WhoSurvived(fighters) + " won.");
		}
	}
}
