using System;
using System.Collections.Generic;

namespace warriorGame
{
    public class Fight
    {
        // utility class, only static methods  TODO class not static - good enough?
        
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
            double attack = RndSrc.Vary(attacker.attackMax, 30, 100);
            double block = RndSrc.Vary(blocker.blockMax, 30, 100);
            double damage = attack - block;
            if (damage < 0) damage = 0; // fighting can only decrease health
            blocker.health -= damage; // TODO design: write to health  vs  return IHealth.health/Human.health (keep health protected?
            blocker.health -= 2f; // fighting exhausts, max 50 moves
            if (blocker.health < 0) blocker.health = 0;  // TODO check within Property (performance..)?

            Console.WriteLine("{0} attack={1:0}  {2} block={3:0} damage={4:0}",
                attacker.name, attack, blocker.name, block, damage);
            Console.WriteLine(blocker.name + " " + blocker.getHealthBar());
        }

        public static Species WhoSurvived(List<Species> fighters)
        {
            Species ret = null;

            // at least one is dead after a fight is over (end of fightLoop)
            if (fighters[0].health > 0)
                ret = fighters[0];
            else if (fighters[1].health > 0)
                ret = fighters[1];

            return ret;
        }

        public static string GetSurvivedName(Species fighter)
        {
            if (fighter != null)
                return fighter.name;
            else
                return "nobody";
        }

        public static void FightersPrint(string title, List<Species> fighters)
        {
            Console.WriteLine(title);
            foreach (Species fighter in fighters)
            {
                fighter.Print();
            }
        }
    }
}