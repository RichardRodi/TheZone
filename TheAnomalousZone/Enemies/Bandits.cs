using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using TheAnomalousZone.MainCharacter;

namespace TheAnomalousZone.Enemies
{
    public class Bandits : BaseEnemy
    {
        public Bandits()
        {

        }
        public Bandits(string name, int health, int damage, int armorValue, int firstAid, int weaponValue, int ammunition, int speed, int numberOfShotsFired)
        {
            Name = name;
            Health = health;
            Damage = damage;
            ArmorValue = armorValue;
            FirstAid = firstAid;
            WeaponValue = weaponValue;
            Ammunition = ammunition;
            Speed = speed;
            NumberOfShotsFired = numberOfShotsFired;
        }
      
    }
}






