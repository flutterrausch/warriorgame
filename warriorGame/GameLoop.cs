using System;
using System.Collections.Generic;
using static System.Environment;

namespace warriorGame
{
	public class GameLoop
	{	
		// Classical Game Loop:
		//	1/ input
		//		. rnd-move-collide-decideIfFightOrMakeLove
		//	2/ update states
		//		- fight
		//			- health
		//		. recover-per-round
		//	3/ output
		//		- print

		private bool _gameOn = true;
		private uint _round = 1;

		public void Start(ref List<Species> players)
		{
			while (_gameOn)
			{
				Console.WriteLine(NewLine + "GAME ROUND " + _round);

				// fight until decision
				Fight.FullFight(ref players);
				// continue game if at least 2 players left
				_gameOn &= (players.Count > 1);

				//fightOn &= Health.RecoverRound(players);


				if (++_round > Const.MaxRounds)  break;
			}

			// game over
			Console.WriteLine(NewLine + "GAME OVER, " +
			                  Fight.GetSurvivedName(Fight.WhoSurvived(players)) +  // players = last pair, TODO It's a bit risky
			                  " is left." + NewLine);
		}
	}
}
