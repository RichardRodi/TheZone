using TheAnomalousZone.Menus;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.MainCharacter
{
    public class MainPlayer : BaseCharacter
    {
        public MainPlayer()
        {

        }
        public MainPlayer(string name, int health, int radiation, int damage, int armorValue, int firstAid, int weaponValue, int ammunitionPerMagazine, int speed,
            string description, int rubles, int maxHealth)
        {
            Name = name;
            Health = health;
            Radiation = radiation;
            Damage = damage;
            ArmorValue = armorValue;
            FirstAid = firstAid;
            WeaponValue = weaponValue;
            Ammunition = ammunitionPerMagazine;
            Speed = speed;
            Description = description;
            Rubles = rubles;
            MaxHealth = maxHealth;
        }
        public void DisplayStats()
        {
            Console.WriteLine($"Character Stats\n\n---------------\n");
            Console.WriteLine($"Name: {Name}\nHealth: {Health}/{MaxHealth}\nArmor Rating: {ArmorValue}\nWeapon Damage: {WeaponValue}\nSpeed: {Speed}\nAmmunition per Magazine: {Ammunition}\nFirstAid Kits: {FirstAid}\nRubles:{Rubles}");
        }
        public void Heal(int minAmountToHeal, int maxAmountToHeal)
        {
            Random random = new Random();
            int amountToHeal = random.Next(minAmountToHeal, maxAmountToHeal + 1);
            if (Health >= MaxHealth)
            {
                Health = MaxHealth;
                Console.WriteLine("\nYou are at full Health!");
            }
            else if (FirstAid <= 0)
            {
                Console.WriteLine("\nYou are out of First Aid Kits!");
            }

            else
            {

                Health += amountToHeal;
                if (Health >= MaxHealth)
                {
                    Health = MaxHealth;
                }
                FirstAid--;
                Console.WriteLine($"\nYou Healed for {amountToHeal} Health");

            }

        }
        public void PlayerDamage(int damage)
        {

            Health -= damage;
            if (Health < 0)
                Health = 0;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            SlowPrint.Print($"You Took {damage} Damage!");
            Console.ResetColor();
            if (Health <= 0)

            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                SlowPrint.Print($"{Name} has ceased to be alive!");
                Console.ReadKey(true);
                Console.ResetColor();
                var deathmenu = new DeathMenu();
                deathmenu.RunEncounter();
            }
        }


    }
}

