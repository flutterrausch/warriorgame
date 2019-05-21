using System;
using System.Collections.Generic;

namespace warriorGame
{
    public static class Fight
    {
        // utility class, only static methods  TODO considered harmful
        
        public static bool FightRound(List<IFightable> fighters)
        {
            Human fighter0 = fighters[0] as Human; // TODO sanity checks -> ConvertToHuman() incl sanity checks
            Human fighter1 = fighters[1] as Human;

            FightOneWay(fighter0, fighter1);
            if (fighter1.health > 0f) // fight back only when still alive - attack is the best form of defense
            {
                FightOneWay(fighter1, fighter0);
            }

            return (fighter0.health > 0f && fighter1.health > 0f); // both survived?
        }

        private static void FightOneWay(Human fighter0, Human fighter1)
        {
            // fighter0 attacks fighter1
            double attack = RndSrc.RndVary(fighter0.attackMax, 30, 100);
            double block = RndSrc.RndVary(fighter1.blockMax, 30, 100);
            double damage = attack - block;
            if (damage < 0) damage = 0; // fighting can only decrease health
            fighter1.health -= damage; // TODO design: write to health  vs  return IHealth.health/Human.health ?
            fighter1.health -= 2f; // fighting exhausts, max 50 moves
            if (fighter1.health < 0) fighter1.health = 0;  // TODO check within Property (performance..)?

            Console.WriteLine("{0} attack={1:0}  {2} block={3:0} damage={4:0}",
                fighter0.name, attack, fighter1.name, block, damage);
            Console.WriteLine(fighter1.name + " " + fighter1.getHealthBar());  // attackee
        }

        public static string WhoSurvived(List<IFightable> fighters)
        {
            string ret = "";

            Human fighter0 = fighters[0] as Human; // TODO sanity checks
            Human fighter1 = fighters[1] as Human;

            // at least one is dead after a fight is over (end of gameLoop)
            if (fighter0.health > 0) ret += fighter0.name;
            if (fighter1.health > 0) ret += fighter1.name;
            if (ret == "") ret = "nobody";

            return ret;
        }

        public static void FightersPrint(List<IFightable> fighters)
        {
            (fighters[0] as Human).Print(); // Print() is Human, TODO sanity checks
            (fighters[1] as Human).Print();
        }
    }
}