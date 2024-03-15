namespace TheAnomalousZone.MainCharacter
{
    public class MainPlayer : BaseCharacter
    {
        public MainPlayer()
        {

        }
        public MainPlayer(string name, int health, int radiation, int damage, int armorValue, int firstAid, int weaponValue, int ammunition, int speed, int numberOfShotsFired,
            string description)
        {
            Name = name;
            Health = health;
            Radiation = radiation;
            Damage = damage;
            ArmorValue = armorValue;
            FirstAid = firstAid;
            WeaponValue = weaponValue;
            Ammunition = ammunition;
            Speed = speed;
            NumberOfShotsFired = numberOfShotsFired;
            Description = description;
        }
        public void DisplayStats()
        {
            Console.WriteLine($"Character Stats\n\n---------------\n\n");
            Console.WriteLine($"Name: {Name}\nHealth \u2661 : {Health}\nRadiation \u2622 : {Radiation}\nArmor Rating  \u26E8 : {ArmorValue}\nWeapon Damage \u2694 : {WeaponValue}\nSpeed: {Speed}");
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

