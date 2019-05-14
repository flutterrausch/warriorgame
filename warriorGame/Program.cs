using System.Collections.Generic;

namespace warriorGame
{
	class Program
	{
		static void Main(string[] args)
		{
			// create fighters
			Human f0 = new Human("f0");
			Human f1 = new Human("f1");
			List<IFightable> fighters = new List<IFightable>();
			fighters.Add(f0);
			fighters.Add(f1);
			
			GameLoop gameLoop = new GameLoop();
			gameLoop.Start(fighters);
		}
	}
}
