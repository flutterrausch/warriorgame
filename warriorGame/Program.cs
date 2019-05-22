using System.Collections.Generic;

namespace warriorGame
{
	class Program
	{
		static void Main()
		{
			// create fighters
			List<Species> fighters = new List<Species>();
			fighters.Add(new Human("f0"));
			fighters.Add(new Human("f1"));
			
			GameLoop gameLoop = new GameLoop();
			gameLoop.Start(fighters);
		}
	}
}
