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

    }
}
