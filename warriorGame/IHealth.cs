namespace warriorGame
{
	public interface IHealth
	{
		double health { get; set; }
		//bool isDead { get; }

		void Recover();
		//string GetPrintString();  // Print() in class implementing Interface

	}
}
