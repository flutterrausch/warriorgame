using System;
namespace warriorGame
{
	public class Human : IFightable, IHealth
	{
		public string name { get; }

		private double _attackMax;
		private double _blockMax;
		private double _health;
		private double _recoverRate;

		public Human(string _name)
		{
			name = _name;
			_attackMax = RndSrc.RndVary(70, 25, 100);
			_blockMax = RndSrc.RndVary(60, 25, 100);  // give those attacks a chance
			_recoverRate = RndSrc.RndVary(70, 25, 100);
			_health = 100f;
		}

		public void Print()
		{
			//IHealth.GetPrintString();  // TODO does it make sense to declare in interface vs implement in class?
			//IFightable.GetPrintString();  // TODO how to access by Interface?
			//   https://stackoverflow.com/questions/2371178/inheritance-from-multiple-interfaces-with-the-same-method-name
			//   https://www.c-sharpcorner.com/article/implementing-multiple-interfaces-with-the-same-method-signature-in-c-sharp/

			Console.WriteLine("{0} attackM={1:0} blockM={2:0} _recRate={3:0} health={4:0}",
				name, attackMax, blockMax, _recoverRate, health);
		}


		// IFightable
		public double attackMax
		{
			get { return _attackMax; }
		}

		public double blockMax
		{
			get { return _blockMax; }
		}

		//string IFightable.GetPrintString()  // public not suitable
		//{
		//	return "attackMax=" + attackMax + " blockMax=" + blockMax;
		//}


		// IHealth
		public double health
		{
			get { return _health; }
			set { _health = value; }
		}

		public void Recover()
		{
			throw new NotImplementedException();
		}

		//string IHealth.GetPrintString()
		//{
		//	return "_recRate=" + _recoverRate + " health=" + health;
		//}

	}
}
