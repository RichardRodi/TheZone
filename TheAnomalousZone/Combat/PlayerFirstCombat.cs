using TheAnomalousZone.Enemies;
using TheAnomalousZone.MainCharacter;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Combat
{
    public static class PlayerFirstCombat
    {

        private static Random random = new Random();

        public static void Fight(MainPlayer player, BaseEnemy enemy)
        {
            SlowPrint.Print($" {player.Name} is now fighting {enemy.Name}!");

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
                SlowPrint.Print($" {enemy.Name} attacks {player.Name} for {enemyDamage} damage.");

                if (!player.IsAlive())
                {
                    SlowPrint.Print($"{player.Name} has been defeated!");
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
