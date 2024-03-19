using System.Media;
using TheAnomalousZone.Enemies;
using TheAnomalousZone.MainCharacter;
using TheAnomalousZone.Menus;
using TheAnomalousZone.Printer;
using static System.Net.Mime.MediaTypeNames;

namespace TheAnomalousZone.Combat
{
    public static class PlayerFirstMutantCombat
    {

        private static Random random = new Random();

        public static void Fight(MainPlayer player, BaseEnemy enemy)
        {
            SlowPrint.Print($" {player.Name} is now fighting {enemy.Name}!");

            while (player.IsAlive() && enemy.IsAlive())
            {
                int ammunition = player.Ammunition;

                for (int i = 0; i < ammunition; i++)
                {
                    SoundPlayer playGunSound = new SoundPlayer(soundLocation: @"glock19.wav");
                    playGunSound.Play();
                    int playerDamage = CalculateDamage(player.WeaponValue, enemy.ArmorValue, player.Speed, enemy.Speed);
                    enemy.TakeDamage(playerDamage);

                    SlowPrint.Print($" {player.Name} fires weapon at {enemy.Name} and hits for {playerDamage} damage.");

                    if (!enemy.IsAlive())
                    {
                        SlowPrint.Print($" {enemy.Name} has been defeated!");
                        int c = random.Next(100, 500);
                        player.Rubles += c;
                        SlowPrint.Print($" {enemy.Name} has been defeated! You Found {c} Rubles in the Mutants Stomach"); ;
                        break;
                    }
                    SoundPlayer playAnimalSound = new SoundPlayer(soundLocation: @"bear.wav");
                    playAnimalSound.Play();
                    int enemyDamage = CalculateDamage(enemy.Damage, player.ArmorValue, player.Speed, enemy.Speed);
                    player.TakeDamage(enemyDamage);
                    SlowPrint.Print($" {enemy.Name} attacks {player.Name} for {enemyDamage} damage.");

                    if (i == ammunition - 1)
                    {
                        SoundPlayer playAnimalReloadSound = new SoundPlayer(soundLocation: @"bear.wav");
                        playAnimalReloadSound.Play();
                        SlowPrint.Print($"{player.Name} is out of ammunition and reloading!");
                        ammunition = 0;
                        enemyDamage = CalculateDamage(enemy.Damage, player.ArmorValue, player.Speed, enemy.Speed);
                        player.TakeDamage(enemyDamage);
                        SoundPlayer playAnimalReloadSecondSound = new SoundPlayer(soundLocation: @"bear.wav");

                        playAnimalReloadSecondSound.Play();
                        SlowPrint.Print($" {enemy.Name} attacks {player.Name} for {enemyDamage} damage.");
                        enemyDamage = CalculateDamage(enemy.Damage, player.ArmorValue, player.Speed, enemy.Speed);
                        player.TakeDamage(enemyDamage);
                        

                    }
                    if (player.Health <= 0)
                    {
                        SlowPrint.Print($"{player.Name} has been defeated!");
                        Console.ReadKey(true);
                        var deathmenu = new DeathMenu();
                        deathmenu.RunEncounter();
                        break;
                    }
                }
            }
        }

        private static int CalculateDamage(int attack, int defense, int playerSpeed, int enemySpeed)
        {

            double hitChance = 0.5 + (playerSpeed - enemySpeed) * 0.05;
            if (random.NextDouble() > hitChance)
            {
                Console.WriteLine("\tAttack Missed!");
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
