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
            Console.WriteLine($"Character Stats\n\n---------------\n\n");
            Console.WriteLine($"Name: {Name}\nHealth \u2661 : {Health}/{MaxHealth}\nArmor Rating  \u26E8 : {ArmorValue}\nWeapon Damage \u2694 : {WeaponValue}\nSpeed \u269E  {Speed}\nAmmunition \u204D  {Ammunition}\nFirstAid Kits: \u2624  {FirstAid}\nRubles \u20BD  {Rubles}");
        }
        public void Heal(int amount)
        {
            
            if (Health >= MaxHealth)
            {
                Health = MaxHealth;
                Console.WriteLine("You are at full Health!");
            }
            else if (FirstAid <= 0)
            {
                Console.WriteLine("You are out if First Aid Kits!");
            }
            else 
            {

                Health += amount;
                FirstAid --;   
                Console.WriteLine($"You Healed for {amount} Health");

                if (Health == MaxHealth) 
                { 
                    Health = MaxHealth;
                    Console.WriteLine("You are now at full health");
                     
                }
              
              
            }
        }

        //public void CreateClassSoldier()
        //{
        //    MainPlayer newSoldier = new MainPlayer(name: "Sergei", health: 40, radiation: 0, damage: 1, armorValue: 8,
        //        firstAid: 1, weaponValue: 10, ammunition: 50, speed: 5, numberOfShotsFired: 3,"You were a soldier in the Ukranian Army");
        //}
        //public void CreateClassSniper()
        //{
        //    MainPlayer newSniper = new MainPlayer(name: "Artyom", health: 20, radiation: 0, damage: 1, armorValue: 3,
        //        firstAid: 2, weaponValue: 20, ammunition: 20, speed: 5, numberOfShotsFired: 1, "You were a sniper in the Ukranian Army");
        //}
        //public void CreateClassScientist()
        //{
        //    MainPlayer newScientist = new MainPlayer(name: "Dimitri", health: 30, radiation: 0, damage: 1, armorValue: 5,
        //        firstAid: 1, weaponValue: 3, ammunition: 50, speed: 5, numberOfShotsFired: 2, "You were a scientist in the Ukranian Army");
        //}

    }
}

