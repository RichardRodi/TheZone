namespace TheAnomalousZone.MainCharacter
{
    public class BaseCharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Radiation { get; set; }
        public int Damage { get; set; }
        public int ArmorValue { get; set; }
        public int FirstAid { get; set; }
        public int RadiationDamage { get; set; }
        public int WeaponValue { get; set; }
        public int Ammunition { get; set; }
        public int Speed { get; set; }
        public int NumberOfShotsFired { get; set; }
        public string Description { get; set; }
        public int Rubles { get; set; }
        public int MaxHealth { get; set; }

        public void TakeDamage(int damage)
        {

            Health -= damage;
            if (Health < 0)
                Health = 0;
        }

        public void TakeRadiationDamage(int radiationDamage)
        {
            Radiation += radiationDamage;
            if (Radiation > 10)
                Radiation = 10;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public void DisplayStats()
        {
            Console.WriteLine($"\n\nCharacter Stats\n\n---------------\n\n");
            Console.WriteLine($"Name: {Name}\nHealth: {Health}\nRadiation: {Radiation}\nArmor Rating: {ArmorValue}\nWeapon Damage: {WeaponValue}\nSpeed: {Speed} \nAmmunition: {Ammunition}");
        }
    }
}

