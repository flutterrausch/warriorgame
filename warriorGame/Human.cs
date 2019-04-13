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