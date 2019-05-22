using System;

namespace warriorGame
{
    public class Human : Species, IHealth
    {
        // IHealth
        public double health { get; set; }

        public string getHealthBar()
        {
            const int total = 30;

            int count = (int) Math.Round(health * (double) total / 100d);
            string bar = "[" + new string('#', count);
            bar = bar.PadRight(total + 1) + "]";
            
            return bar;
        }

        
        // Human
        public string name { get; }

        public Human(string _name)
        {
            name = _name;
            health = 100f;
            
            attackMax = RndSrc.RndVary(70, 25, 100);
            blockMax = RndSrc.RndVary(60, 25, 100); // give those attacks a chance
        }

        public void Print()
        {
            Console.WriteLine("{0} attackM={1:0} blockM={2:0} health={3:0}", name, attackMax, blockMax, health);
        }
    }
}