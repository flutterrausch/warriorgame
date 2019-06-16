using System;

namespace warriorGame
{
    public class Human : Species
    {
        public Human(string name) : base(name)
        {
            attackMax = RndSrc.Vary(70, 25, 100);
            blockMax = RndSrc.Vary(60, 25, 100); // give those attacks a chance
        }
    }
}