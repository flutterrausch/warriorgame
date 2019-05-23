using System;

namespace warriorGame
{
    public class Human : Species
    {
        public Human(string _name) : base(_name)
        {
            attackMax = RndSrc.RndVary(70, 25, 100);
            blockMax = RndSrc.RndVary(60, 25, 100); // give those attacks a chance
        }
    }
}