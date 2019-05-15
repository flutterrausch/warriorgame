using System.Collections.Generic;

namespace warriorGame
{
	class Program
	{
		static void Main()
		{
			// create fighters
			List<IFightable> fighters = new List<IFightable>();
			fighters.Add(new Human("f0"));
			fighters.Add(new Human("f1"));
			
			GameLoop gameLoop = new GameLoop();
			gameLoop.Start(fighters);
		}
	}
}
