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
            Console.WriteLine($"\n\tCharacter Stats\n\n\t---------------\n");
            Console.WriteLine($"\tName: {Name}\n\tHealth: {Health}/{MaxHealth}\n\tArmor Rating: {ArmorValue}\n\tWeapon Damage: {WeaponValue}\n\tSpeed: {Speed}\n\tAmmunition per Magazine: {Ammunition}\n\tFirstAid Kits: {FirstAid}\n\tRubles:{Rubles}");
        }
        public void Heal(int minAmountToHeal, int maxAmountToHeal)
        {
            Random random = new Random();
            int amountToHeal = random.Next(minAmountToHeal, maxAmountToHeal + 1);
            if (Health >= MaxHealth)
            {
                Health = MaxHealth;
                Console.WriteLine("\n\tYou are at full Health!");
            }
            else if (FirstAid <= 0)
            {
                Console.WriteLine("\n\tYou are out of First Aid Kits!");
            }

            else
            {

                Health += amountToHeal;
                if (Health >= MaxHealth)
                {
                    Health = MaxHealth;
                }
                FirstAid--;
                Console.WriteLine($"\n\tYou Healed for {amountToHeal} Health");

            }

        }
        public void PlayerDamage(int damage)
        {

            Health -= damage;
            if (Health < 0)
                Health = 0;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            SlowPrint.Print($"\tYou Took {damage} Damage!");
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

