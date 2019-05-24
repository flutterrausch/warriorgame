using System;
using System.Collections.Generic;

namespace warriorGame
{
    public static class Fight
    {
        // utility class, only static methods  TODO considered harmful
        
        public static bool FightRound(List<Species> fighters)
        {
            FightOneWay(fighters[0], fighters[1]);
            if (fighters[0].health > 0f) // fight back only when still alive - attack is the best form of defense
            {
                FightOneWay(fighters[1], fighters[0]);
            }

            return (fighters[0].health > 0f && fighters[1].health > 0f); // both survived?
        }

        private static void FightOneWay(Species attacker, Species blocker)
        {
            double attack = RndSrc.RndVary(attacker.attackMax, 30, 100);
            double block = RndSrc.RndVary(blocker.blockMax, 30, 100);
            double damage = attack - block;
            if (damage < 0) damage = 0; // fighting can only decrease health
            blocker.health -= damage; // TODO design: write to health  vs  return IHealth.health/Human.health (keep health protected?
            blocker.health -= 2f; // fighting exhausts, max 50 moves
            if (blocker.health < 0) blocker.health = 0;  // TODO check within Property (performance..)?

            Console.WriteLine("{0} attack={1:0}  {2} block={3:0} damage={4:0}",
                attacker.name, attack, blocker.name, block, damage);
            Console.WriteLine(blocker.name + " " + blocker.getHealthBar());
        }

        public static string WhoSurvived(List<Species> fighters)
        {
            string ret = "";

            // at least one is dead after a fight is over (end of gameLoop)
            if (fighters[0].health > 0) ret += fighters[0].name; // TODO sanity checks
            if (fighters[1].health > 0) ret += fighters[1].name;
            if (ret == "") ret = "nobody";

            return ret;
        }

        public static void FightersPrint(List<Species> fighters)
        {
            fighters[0].Print(); // TODO sanity checks
            fighters[1].Print();
        }
    }
}