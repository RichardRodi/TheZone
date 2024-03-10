using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAnomalousZone.Enemies
{
    public class BaseEnemy
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

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > Health)
                Health = Health;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
        public bool IsAliveFromRadiation()
        {
            return Radiation < 10;
        }
        public void DisplayStats()
        {
            Console.WriteLine($"\n\nEnemy Stats\n\n---------------\n\n");
            Console.WriteLine($"Name: {Name}\nHealth: {Health}\nRadiation: {Radiation}\nArmor Rating: {ArmorValue}\nWeapon Damage: {WeaponValue}\nSpeed: {Speed} \n Ammunition: {Ammunition}");
        }
    }
}

