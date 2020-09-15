using System.Collections.Generic;

namespace warriorGame
{
	class Program
	{
		static void Main()
		{
			// create fighters
			List<Species> fighters = new List<Species> {
				new Human("h0"),
				new Ork("o0"),
				new Human("h1"),
				new Ork("o1")
			};

			// let the game(s) begin
			GameLoop.Run(ref fighters);		
		}
	}
}
