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

		private bool _gameOn;


		public void Start(ref List<Species> fighters)  // TODO fight rounds only, need enclosing game rounds
		{
			List<Species> pair = RndSrc.PairFromList(ref fighters);  // TODO sanity check here (or exception in method)
			Fight.FightersPrint("upcoming fight pair:", pair);

			_gameOn = true;
			uint round = 1;
			while (_gameOn)
			{
				Console.WriteLine(NewLine + "round " + round);

				_gameOn &= Fight.FightRound(pair);
				//_gameOn &= Health.RecoverRound(fighters);

				if (++round > 100)  break;
			}

			Species survivor = Fight.WhoSurvived(pair);
			if (survivor != null)
			{
				survivor.health = 100d;
				fighters.Add(survivor);
			}
			Console.WriteLine(NewLine + "Fight Over, " + Fight.GetSurvivedName(survivor) + " won." + NewLine);
		}
	}
}
