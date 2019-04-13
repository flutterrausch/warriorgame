using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace warriorGame
{
	class Program
	{
		static void Main(string[] args)
		{
			// create fighters
			List<IFightable> fighters = new List<IFightable>();
			Human f0 = new Human("f0"); fighters.Add(f0);
			Human f1 = new Human("f1"); fighters.Add(f1);
			
			GameLoop gameLoop = new GameLoop();
			gameLoop.Start(fighters);
		}
	}
}
