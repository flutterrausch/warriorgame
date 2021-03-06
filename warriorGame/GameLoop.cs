﻿using System;
using System.Collections.Generic;
using static System.Environment;

namespace warriorGame
{
	public static class GameLoop
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

		private static bool _gameOn = true;
		private static uint _gameRound = 1;

		public static void Run(ref List<Species> players)
		{
			while (_gameOn)
			{
				Console.WriteLine(NewLine + "GAME ROUND " + _gameRound);

				// fight until decision
				Fight.FullFight(ref players);
				// continue game if at least 2 players left
				_gameOn &= (players.Count > 1);

				//_gameOn &= Health.RecoverRound(players);


				if (++_gameRound > Const.MaxRounds)  break;
			}

			// game over
			Console.Write(NewLine + "GAME OVER, ");
			if (players.Count > 0) // TODO testcase for both dead (sth off in survived())
				Console.WriteLine(Fight.GetSurvivedName(Fight.WhoSurvived(players)) + " is left." + NewLine);
			else
				Console.WriteLine("They all dead." + NewLine);
		}
	}
}
