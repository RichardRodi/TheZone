using System.Media;
using TheAnomalousZone.Enemies;
using TheAnomalousZone.MainCharacter;
using TheAnomalousZone.Menus;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Combat
{
    public class BanditCombat
    {

        private static Random random = new Random();

        public static void FightPlayerFirst(MainPlayer player, BaseEnemy enemy)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            SlowPrint.Print($" {player.Name} is now fighting {enemy.Name}!");

            while (player.Health > 0 && enemy.Health > 0)
            {
                int ammunition = player.Ammunition;

                for (int i = 0; i < ammunition; i++)
                {

                    SoundPlayer playGunSound = new SoundPlayer(soundLocation: @"glock19.wav");
                    playGunSound.Play();
                    int playerDamage = CalculateDamage(player.WeaponValue, enemy.ArmorValue, player.Speed, enemy.Speed);
                    enemy.TakeDamage(playerDamage);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    SlowPrint.Print($"{player.Name} fires weapon at {enemy.Name} and hits for {playerDamage} damage.");

                    playGunSound.Play();
                    int enemyDamage = CalculateDamage(enemy.WeaponValue, player.ArmorValue, player.Speed, enemy.Speed);
                    player.TakeDamage(enemyDamage);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    SlowPrint.Print($"{enemy.Name} attacks {player.Name} for {enemyDamage} damage.");

                    if (i == ammunition - 1 && player.Health > 0 && enemy.Health > 0)
                    {

                        //playGunSound.Play(); should change this to reloading SFX
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        SlowPrint.Print($"{player.Name} is out of ammunition and reloading!");
                        ammunition = 0;
                        enemyDamage = CalculateDamage(enemy.WeaponValue, player.ArmorValue, player.Speed, enemy.Speed);
                        player.TakeDamage(enemyDamage);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        SlowPrint.Print($"{enemy.Name} attacks {player.Name} for {enemyDamage} damage.");
                    }
                    if (player.Health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        SlowPrint.Print($"{player.Name} has been defeated!");
                        Console.ReadKey(true);
                        Console.ResetColor();
                        var deathmenu = new DeathMenu();
                        deathmenu.RunEncounter();

                    }
                    if (enemy.Health <= 0)
                    {
                        int c = random.Next(200, 750);
                        player.Rubles += c;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        SlowPrint.Print($"{enemy.Name} has been defeated! You Found {c} Rubles in the Bandit's Pockets.");
                        Console.ResetColor();
                        break;
                    }
                }
            }

        }

        public static void FightBanditFirst(MainPlayer player, BaseEnemy enemy)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            SlowPrint.Print($" {player.Name} is now fighting {enemy.Name}!");

            while (player.Health > 0 && enemy.Health > 0)
            {

                int ammunition = player.Ammunition;

                for (int i = 0; i < ammunition; i++)
                {
                    SoundPlayer playAnimalSound = new SoundPlayer(soundLocation: @"glock19.wav");
                    playAnimalSound.Play();
                    int enemyDamage = CalculateDamage(enemy.WeaponValue, player.ArmorValue, enemy.Speed, player.Speed);
                    player.TakeDamage(enemyDamage);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    SlowPrint.Print($"{enemy.Name} attacks {player.Name} for {enemyDamage} damage.");

                    SoundPlayer playGunSound = new SoundPlayer(soundLocation: @"glock19.wav");
                    playGunSound.Play();
                    int playerDamage = CalculateDamage(player.WeaponValue, enemy.ArmorValue, enemy.Speed, player.Speed);
                    enemy.TakeDamage(playerDamage);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    SlowPrint.Print($"{player.Name} fires weapon at {enemy.Name} and hits for {playerDamage} damage.");

                    if (i == ammunition - 1 && player.Health > 0 && enemy.Health > 0)
                    {

                        //playGunSound.Play(); should change this to reloading SFX
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        SlowPrint.Print($"{player.Name} is out of ammunition and reloading!");
                        ammunition = 0;
                        enemyDamage = CalculateDamage(enemy.WeaponValue, player.ArmorValue, enemy.Speed, player.Speed);
                        player.TakeDamage(enemyDamage);
                        playGunSound.Play();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        SlowPrint.Print($"{enemy.Name} attacks {player.Name} for {enemyDamage} damage.");

                    }
                    if (player.Health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        SlowPrint.Print($"{player.Name} has been defeated!");
                        Console.ReadKey(true);
                        var deathmenu = new DeathMenu();
                        deathmenu.RunEncounter();

                    }

                    if (enemy.Health <= 0)
                    {
                        int c = random.Next(200, 750);
                        player.Rubles += c;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        SlowPrint.Print($"{enemy.Name} has been defeated! You Found {c} Rubles in the Bandit's Pockets.");
                        Console.ResetColor();
                        break;
                    }

                }
            }
        }

        private static int CalculateDamage(int attack, int defense, int playerSpeed, int enemySpeed)
        {

            double hitChance = 0.8 + (playerSpeed - enemySpeed) * 0.015;
            if (random.NextDouble() > hitChance)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"Attack Missed!");
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
