namespace warriorGame
{
    public class Human : Species
    {
        public Human(string name) : base(name)
        {
            // attack > block ensures finite battles
            attackMax = RndSrc.Vary(70d, 25d, Const.MaxPercent);
            blockMax = RndSrc.Vary(60d, 25d, Const.MaxPercent);
        }
    }
}