using TheAnomalousZone.MainCharacter;

namespace TheAnomalousZone.Enemies
{
    public class MutatedAnimals : BaseEnemy
    {
        public MutatedAnimals()
        {

        }
        public MutatedAnimals(string name, int health, int damage, int armorValue, int radiationDamage, int speed, string description)
        {
            Name = name;
            Health = health;
            Damage = damage;
            ArmorValue = armorValue;
            RadiationDamage = radiationDamage;
            Speed = speed;
            Description = description;
        }

        //public static List<MutatedAnimals> CreateEnemyList()
        //{
        //    List<MutatedAnimals> mutatedEnemies = new List<MutatedAnimals>();

        //    mutatedEnemies.Add(new MutatedAnimals("MutatedBoar", health: 15, damage: 1, armorValue: 4, radiationDamage: 1,
        //          speed: 5, "This is a mutated boar"));

        //    mutatedEnemies.Add(new MutatedAnimals("MutatedChimera", health: 20, damage: 1, armorValue: 5, radiationDamage: 1,
        //        speed: 5, "This is a mutated chimera"));

        //    mutatedEnemies.Add(new MutatedAnimals("MutatedSnork", health: 10, damage: 1, armorValue: 5, radiationDamage: 1,
        //         speed: 5, "This is a mutated snork"));

        //    return mutatedEnemies;
        //}
    }
}
