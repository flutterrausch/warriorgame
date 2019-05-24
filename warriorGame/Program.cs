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
			
			Testos testos = new Testos();  // instance possible
			//testos.FightersPrint(fighters); // cannot be accessed with an instance reference; qualify it with a type name instead
			Testos.FightersPrint(fighters);
				
			GameLoop gameLoop = new GameLoop();
			gameLoop.Start(fighters);
		}
	}
}
