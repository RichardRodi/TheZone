﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using TheAnomalousZone.Enemies;
using TheAnomalousZone.MainCharacter;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Combat
{
    internal class PlayerFirstBanditCombat
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
                        int playerDamage = CalculateDamage(player.WeaponValue, enemy.ArmorValue);
                        enemy.TakeDamage(playerDamage);

                        SlowPrint.Print($" {player.Name} fires weapon at {enemy.Name} and hits for {playerDamage} damage.");

                        if (!enemy.IsAlive())
                        {
                            int c = random.Next(200, 750);
                            player.Rubles += c;
                            SlowPrint.Print($" {enemy.Name} has been defeated! You Found {c} Rubles in the Bandits Pocket");
                            break;
                        }
                        SoundPlayer playAnimalSound = new SoundPlayer(soundLocation: @"glock19.wav");
                        playAnimalSound.Play();
                        int enemyDamage = CalculateDamage(enemy.Damage, player.ArmorValue);
                        player.TakeDamage(enemyDamage);
                        SlowPrint.Print($" {enemy.Name} attacks {player.Name} for {enemyDamage} damage.");

                        if (i == ammunition - 1)
                        {
                            SoundPlayer playAnimalReloadSound = new SoundPlayer(soundLocation: @"glock19.wav");
                            playAnimalReloadSound.Play();
                            SlowPrint.Print($"{player.Name} is out of ammunition and reloading!");
                            ammunition = 0;
                            enemyDamage = CalculateDamage(enemy.Damage, player.ArmorValue);
                            player.TakeDamage(enemyDamage);
                            SoundPlayer playAnimalReloadSecondSound = new SoundPlayer(soundLocation: @"glock19.wav");

                            playAnimalReloadSecondSound.Play();
                            SlowPrint.Print($" {enemy.Name} attacks {player.Name} for {enemyDamage} damage.");
                            enemyDamage = CalculateDamage(enemy.Damage, player.ArmorValue);
                            player.TakeDamage(enemyDamage);
                            SlowPrint.Print($" {enemy.Name} attacks {player.Name} for {enemyDamage} damage.");

                        }
                        if (!player.IsAlive())
                        {
                            SlowPrint.Print($"{player.Name} has been defeated!");
                            break;
                        }
                    }
                }
            }

            private static int CalculateDamage(int attack, int defense)
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
