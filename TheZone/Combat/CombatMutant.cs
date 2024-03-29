﻿using TheZone.Base;
using TheZone.MainPlayers;
using TheZone.Menus;
using TheZone.Printer;

namespace TheZone.Combat
{
    public class CombatMutant
    {

        private static Random random = new Random();

        public static void Fight(MainPlayer player, BaseCharacter enemy)
        {
            SlowPrint.Print($" {player.Name} is now fighting a {enemy.Name}!");

            while (player.IsAlive() && enemy.IsAlive() && player.IsAliveFromRadiation())
           
            {
                
                int playerDamage = CalculateDamage(player.WeaponValue, enemy.ArmorValue);
                enemy.TakeDamage(playerDamage);
                SlowPrint.Print($" {player.Name} fires weapon at {enemy.Name} and hits for {playerDamage} damage.");

                if (!enemy.IsAlive())
                {
                    SlowPrint.Print($" {enemy.Name} has been defeated!");
                    break;
                }

                int enemyDamage = CalculateDamage(enemy.Damage, player.ArmorValue);
                player.TakeDamage(enemyDamage);
                SlowPrint.Print($" {enemy.Name} claws {player.Name} for {enemyDamage} damage.");

                if (!player.IsAlive())
                {
                    SlowPrint.Print($"{player.Name} has been defeated!");
                    DeathMenu newMenu = new DeathMenu();
                    newMenu.DeathScreen();
                    break;
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






