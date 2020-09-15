namespace warriorGame
{
	public class Ork : Species
	{
		public Ork(string _name) : base(_name)
		{
			// attack > block ensures finite battles
			attackMax = RndSrc.Vary(90d, 25d, Const.MaxPercent);
			blockMax = RndSrc.Vary(70d, 25d, Const.MaxPercent);
		}
	}
}