using System;

namespace warriorGame
{
    public class Human : IFightable, IHealth
    {
        // IFightable
        public double attackMax { get; }
        public double blockMax { get; }


        // IHealth
        public double health { get; set; }

        public string getHealthBar()
        {
            const int total = 30;

            double count = Math.Round(((double)health / 100f) * total);
            // if (count == 0  &&  Alive())  count = 1;
            string bar = "[";
            for (int i = 0; i < count; i++)  bar += "#";

            return bar.PadRight(total + 1) + "]";
        }

        
        // Human
        public string name { get; }

        public Human(string _name)
        {
            name = _name;
            attackMax = RndSrc.RndVary(70, 25, 100);
            blockMax = RndSrc.RndVary(60, 25, 100); // give those attacks a chance
            health = 100f;
        }

        public void Print()
        {
            Console.WriteLine("{0} attackM={1:0} blockM={2:0} health={3:0}", name, attackMax, blockMax, health);
        }
    }
}