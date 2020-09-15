using System;
using static System.Environment;
using System.Collections.Generic;

namespace warriorGame
{
    public static class Fight // TODO singleton vs static?
    {
        // all things fight: FullFight = N * FightRound = 2 * FightOneWay + some helpers

        private static uint _fightCnt = 0;
        
        
        public static bool FullFight(ref List<Species> fighters)
        {
            // N rounds of fight until one is dead
            
            List<Species> pair = RndSrc.PairFromList(ref fighters);  // TODO sanity check here (or exception in method)
            uint fightRound = 1;
            bool fightOn = true;
            bool retHasSurvivor = true;
            
            Console.WriteLine("Fight No " + ++_fightCnt);
            FightersPrint("all fighters:", fighters);
            FightersPrint("upcoming fight pair:", pair);

            // fight all necessary rounds
            while (fightOn)
            {
                fightOn &= FightRound(pair, fightRound); // both survived?
                fightOn &= (++fightRound < Const.MaxRounds); // MaxRounds?
                
                //fightOn &= Health.RecoverInFight(fighters);
            }

            // recover survivor, if any
            Species survivor = WhoSurvived(pair);
            if (survivor != null)
            {
                survivor.health = Const.MaxPercent;
                fighters.Add(survivor);
            }
            else
            {
                retHasSurvivor = false;
            }
            Console.WriteLine(NewLine + "Fight Over, " + GetSurvivedName(survivor) + " won." + NewLine);
            
            return retHasSurvivor;
        }


        private static bool FightRound(IReadOnlyList<Species> fighters, uint fightRound) // IReadOnlyList = const List<Species>
        {
            // one round of both-way fight
            
            Console.WriteLine(NewLine + "fight round " + fightRound);
            FightOneWay(fighters[0], fighters[1]);
            if (fighters[0].health > 0d) // fight back only when still alive - attack is the best form of defense
            {
                FightOneWay(fighters[1], fighters[0]);
            }

            return (fighters[0].health > 0d && fighters[1].health > 0d); // both survived?
        }

        
        private static void FightOneWay(Species attacker, Species blocker)
        {
            // 30% scatter to players abilities
            double attack = RndSrc.Vary(attacker.attackMax, 30d, Const.MaxPercent);
            double block = RndSrc.Vary(blocker.blockMax, 30d, Const.MaxPercent);
            
            // calculate BANG result for blocker
            double damage = attack - block;
            if (damage < 0) damage = 0; // fighting can only decrease health
            blocker.health -= damage; // TODO design: write to health  vs  return health (write protected)?
            blocker.health -= (double) Const.MaxPercent/Const.MaxFightMoves; // each fight move also exhausts = limit moves (both fighters block)
            if (blocker.health < 0) blocker.health = 0;  // TODO check within Property (performance..)?

            // visualize the result of the attack
            Console.WriteLine("{0} attack={1:0}  {2} block={3:0} damage={4:0}", attacker.name, attack, blocker.name, block, damage);
            Console.WriteLine(blocker.name + " " + blocker.getHealthBar());
        }

        public static Species WhoSurvived(List<Species> fighters)
        {
            // return who is dead after a fight is over (at least one, end of fightLoop)
            Species ret = null;

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

        private static void FightersPrint(string title, List<Species> fighters)
        {
            Console.WriteLine(title);
            foreach (Species fighter in fighters)
            {
                fighter.Print();
            }
            Console.WriteLine();
        }
    }
}