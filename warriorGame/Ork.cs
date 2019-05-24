namespace warriorGame
{
	public class Ork : Species
	{
		public Ork(string _name) : base(_name)
		{
			attackMax = RndSrc.RndVary(90, 25, 100);
			blockMax = RndSrc.RndVary(70, 25, 100); // give those attacks a chance
		}
	}
}