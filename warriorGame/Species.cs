namespace warriorGame
{
	public class Species
	{
		private double _attackMax;
		private double _blockMax;
		
		
		public double attackMax  // TODO protected?!
		{
			get { return _attackMax; }
			set { _attackMax = value; }
		}

		public double blockMax
		{
			get { return _blockMax; }
			set { _blockMax = value; }
		}
	}
}