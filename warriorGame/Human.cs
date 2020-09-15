namespace warriorGame
{
    public class Human : Species
    {
        public Human(string name) : base(name)
        {
            // attack > block ensures finite battles
            AttackMax = RndSrc.Vary(70d, 25d, Const.MaxPercent);
            BlockMax = RndSrc.Vary(60d, 25d, Const.MaxPercent);
        }
    }
}