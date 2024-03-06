using TheZone.Base;

namespace TheZone.Enemies
{
    public class MutatedBoar : BaseCharacter
    {
        public MutatedBoar()
        {
                
        }
        public MutatedBoar(string name, int health, int damage, int armorValue, int radiationDamage, int speed)
        {
            Name = name;
            Health = health;
            Damage = damage;
            ArmorValue = armorValue;
            RadiationDamage = radiationDamage;
            Speed = speed;
        }
        
    }
}
