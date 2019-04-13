using System;
using System.Collections.Generic;

namespace warriorGame
{
	public class GameLoop
	{
		//	1/ input
		//		. rnd-move
		//	2/ update states
		//		- fight
		//			- health
		//		. recovery-per-round
		//	3/ output
		//		- print

		private bool _gameOn = true;


		public void Start(List<IFightable> fighters)
		{
			uint round = 1;
			FightersPrint(fighters);

			while (_gameOn)
			{
				Console.WriteLine(Environment.NewLine + "round " + round);
				_gameOn &= FightRound(fighters);

				if (++round > 100)  break;
			}

			Console.WriteLine(Environment.NewLine + "Game Over, " + WhoSurvived(fighters) + " won.");
		}


		// TODO hide/abstract from gameLoop
		//   - Fight class for IFightable interface? -> no, bloats Human
		//   - Fight utility class with just static methods
		private bool FightRound(List<IFightable> fighters)
		{
			Human fighter0 = fighters[0] as Human;  // TODO sanity checks
			Human fighter1 = fighters[1] as Human;

			FightOneWay(fighter0, fighter1);
			if (fighter1.health > 0f)  // fight back only when still alive - attack is the best form of defense
			{
				FightOneWay(fighter1, fighter0);
			}
			
			return (fighter0.health > 0f && fighter1.health > 0f);  // both survived?
		}

		// fighter0 attacks fighter1
		private void FightOneWay(Human fighter0, Human fighter1)  
		{
			double attack = RndSrc.RndVary(fighter0.attackMax, 30, 100);
			double block = RndSrc.RndVary(fighter1.blockMax, 30, 100);
			double damage = attack - block;
			if (damage < 0) damage = 0; // fighting can only decrease health
			fighter1.health -= damage;  // TODO write to health  vs  return (type IHealth.health / Human.health) ?
			fighter1.health -= 2f;  // fighting exhausts, max 50 moves
			if (fighter1.health < 0) fighter1.health = 0;

			Console.WriteLine("{0} attack={1:0}  {2} block={3:0} damage={4:0} health={5:0}",
				fighter0.name, attack, fighter1.name, block, damage, fighter1.health);
		}

		private void FightersPrint(List<IFightable> fighters)
		{
			(fighters[0] as Human).Print();  // Print() is Human, TODO sanity checks
			(fighters[1] as Human).Print();
		}

		private string WhoSurvived(List<IFightable> fighters)
		{
			string ret = "";

			Human fighter0 = fighters[0] as Human;  // TODO sanity checks -> ConvertToHuman() incl sanity checks
			Human fighter1 = fighters[1] as Human;

			// at least one is dead after a fight is over (end of gameLoop)
			if (fighter0.health > 0) ret += fighter0.name;
			if (fighter1.health > 0) ret += fighter1.name;
			if (ret == "") ret = "nobody";

			return ret;
		}

	}
}
