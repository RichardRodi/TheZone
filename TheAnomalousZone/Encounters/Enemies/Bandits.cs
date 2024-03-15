using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using TheAnomalousZone.MainCharacter;

namespace TheAnomalousZone.Encounters.Enemies
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
        //public static List<Bandits> CreateEnemyList()
        //{
        //    List<Bandits> banditEnemies = new List<Bandits>();

        //    banditEnemies.Add(new Bandits("Bandit Soldier", health: 15, damage: 1, armorValue: 4,
        //        firstAid: 1, weaponValue: 5, ammunition: 25, speed: 5, numberOfShotsFired: 3));

        //    banditEnemies.Add(new Bandits("Bandit Leader", health: 20, damage: 1, armorValue: 5,
        //        firstAid: 2, weaponValue: 15, ammunition: 20, speed: 5, numberOfShotsFired: 1));

        //    banditEnemies.Add(new Bandits("Bandit Scout", health: 10, damage: 1, armorValue: 5,
        //        firstAid: 1, weaponValue: 3, ammunition: 50, speed: 5, numberOfShotsFired: 2));

        //    return banditEnemies;
        //}
    }
}






