using System;
using System.Collections.Generic;

namespace warriorGame
{
	class Program
	{
		static void Main()
		{
			// create fighters
			List<Species> fighters = new List<Species>();
			fighters.Add(new Human("h0"));
			fighters.Add(new Ork("o0"));
			fighters.Add(new Human("h1"));
			fighters.Add(new Ork("o1"));
			
			GameLoop gameLoop = new GameLoop();
			gameLoop.Start(fighters);
		}
	}
}
