using TheZone.Base;

namespace TheZone.MainPlayers
{
    public class MainPlayer : BaseCharacter
    {
       
    
    public MainPlayer()
        {

        }
        public MainPlayer(string name, int health, int radiation, int damage, int armorValue, int firstaid, int weaponValue, int speed)
        {
            Name = name;
            Health = health;
            Radiation = radiation;
            Damage = damage;
            ArmorValue = armorValue;
            FirstAid = firstaid;
            WeaponValue = weaponValue;
            Speed = speed;
        }

        

    }
}
