using System;
using TheAnomalousZone.Enemies;
using TheAnomalousZone.MainCharacter;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Combat
{
    public static class RunAway
    {
        public static bool Run(MainPlayer player, BaseEnemy enemy)

        {
            double chanceToEscape = (player.Speed / enemy.Speed) * 101;

            Random rand = new Random();
            int randomNumber = rand.Next(0, 101);
            if (randomNumber <= chanceToEscape)

            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                SlowPrint.Print("You Got Away!");
                Console.ResetColor();
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                SlowPrint.Print($"You Failed To Get Away from the {enemy.Name}!");
                Console.ResetColor();
                return false;
            }

        }


    }
}
