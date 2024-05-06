using TheAnomalousZone.Enemies;
using TheAnomalousZone.MainCharacter;
using TheAnomalousZone.Menus;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Combat
{
    public class MutantCombat
    {

        private static Random random = new Random();

        public static void FightPlayerFirstMutant(MainPlayer player, BaseEnemy enemy)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            SlowPrint.Print($"\n\t\t{player.Name} is now fighting a {enemy.Name}!");

            while (player.Health > 0 && enemy.Health > 0)
            {
                int ammunition = player.Ammunition;

                for (int i = 0; i < ammunition; i++)
                {

                    int playerDamage = CalculateDamage(player.WeaponValue, enemy.ArmorValue, player.Speed, enemy.Speed);
                    enemy.TakeDamage(playerDamage);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    SlowPrint.Print($"\t{player.Name} fires weapon at {enemy.Name} and hits for {playerDamage} damage.");

                    if (player.Health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        SlowPrint.Print($"\t{player.Name} has been defeated!");
                        Console.ReadKey(true);
                        Console.ResetColor();
                        var deathmenu = new DeathMenu();
                        deathmenu.RunEncounter();
                        break;
                    }
                    if (enemy.Health <= 0)
                    {
                        int c = random.Next(200, 750);
                        player.Rubles += c;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        SlowPrint.Print($"\t{enemy.Name} has been defeated! You Found {c} Rubles in the Mutants Stomach.");
                        Console.ResetColor();
                        Console.ReadKey(true);
                        break;
                    }


                    int enemyDamage = CalculateDamage(enemy.Damage, player.ArmorValue, player.Speed, enemy.Speed);
                    player.TakeDamage(enemyDamage);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    SlowPrint.Print($"\t{enemy.Name} attacks {player.Name} for {enemyDamage} damage.");

                    if (i == ammunition - 1 && player.Health > 0 && enemy.Health > 0)
                    {


                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        SlowPrint.Print($"\t{player.Name} is out of ammunition and reloading!");
                        ammunition = 0;

                        enemyDamage = CalculateDamage(enemy.Damage, player.ArmorValue, enemy.Speed, player.Speed);
                        player.TakeDamage(enemyDamage);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        SlowPrint.Print($"\t{enemy.Name} attacks {player.Name} for {enemyDamage} damage.");


                    }
                    if (player.Health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        SlowPrint.Print($"\t{player.Name} has been defeated!");
                        Console.ReadKey(true);
                        Console.ResetColor();
                        var deathmenu = new DeathMenu();
                        deathmenu.RunEncounter();
                        break;
                    }
                    if (enemy.Health <= 0)
                    {
                        int c = random.Next(200, 750);
                        player.Rubles += c;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        SlowPrint.Print($"\t{enemy.Name} has been defeated! You Found {c} Rubles in the Mutant's Stomach.");
                        Console.ResetColor();
                        Console.ReadKey(true);
                        break;
                    }
                }
            }

        }

        public static void FightMutantFirst(MainPlayer player, BaseEnemy enemy)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            SlowPrint.Print($"\n\t\t{player.Name} is now fighting a {enemy.Name}!");

            while (player.Health > 0 && enemy.Health > 0)
            {

                int ammunition = player.Ammunition;

                for (int i = 0; i < ammunition; i++)
                {

                    int enemyDamage = CalculateDamage(enemy.Damage, player.ArmorValue, enemy.Speed, player.Speed);
                    player.TakeDamage(enemyDamage);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    SlowPrint.Print($"\t{enemy.Name} attacks {player.Name} for {enemyDamage} damage.");

                    if (player.Health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        SlowPrint.Print($"\t{player.Name} has been defeated!");
                        Console.ReadKey(true);
                        Console.ResetColor();
                        var deathmenu = new DeathMenu();
                        deathmenu.RunEncounter();
                        break;
                    }
                    if (enemy.Health <= 0)
                    {
                        int c = random.Next(200, 750);
                        player.Rubles += c;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        SlowPrint.Print($"\t{enemy.Name} has been defeated! You Found {c} Rubles in the Mutants's Pockets.");
                        Console.ResetColor();
                        Console.ReadKey(true);
                        break;
                    }


                    int playerDamage = CalculateDamage(player.WeaponValue, enemy.ArmorValue, enemy.Speed, player.Speed);
                    enemy.TakeDamage(playerDamage);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    SlowPrint.Print($"\t{player.Name} fires weapon at {enemy.Name} and hits for {playerDamage} damage.");

                    if (i == ammunition - 1 && player.Health > 0 && enemy.Health > 0)
                    {


                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        SlowPrint.Print($"\t{player.Name} is out of ammunition and reloading!");
                        ammunition = 0;

                        enemyDamage = CalculateDamage(enemy.Damage, player.ArmorValue, enemy.Speed, player.Speed);
                        player.TakeDamage(enemyDamage);

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        SlowPrint.Print($"\t{enemy.Name} attacks {player.Name} for {enemyDamage} damage.");

                    }
                    if (player.Health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        SlowPrint.Print($"\t{player.Name} has been defeated!");
                        Console.ReadKey(true);
                        var deathmenu = new DeathMenu();
                        Console.ResetColor();
                        deathmenu.RunEncounter();
                        break;
                    }

                    if (enemy.Health <= 0)
                    {
                        int c = random.Next(200, 750);
                        player.Rubles += c;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        SlowPrint.Print($"\t{enemy.Name} has been defeated! You Found {c} Rubles in the Mutant's Stomach.");
                        Console.ResetColor();
                        Console.ReadKey(true);
                        break;
                    }

                }
            }
        }

        private static int CalculateDamage(int attack, int defense, int playerSpeed, int enemySpeed)
        {

            double hitChance = 0.875 + (playerSpeed - enemySpeed) * 0.015;
            if (random.NextDouble() > hitChance)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"\tAttack Missed!");
                return 0;

            }
            else
            {
                double damageMultiplier = random.NextDouble() * 0.75 + 1.25;
                int damage = (int)(attack * damageMultiplier) - defense;
                if (damage < 0)
                    damage = 0;
                return damage;
            }
        }

    }
}
