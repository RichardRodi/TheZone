namespace TheZone.Base
{
    public abstract class BaseCharacter
    {
        public string Name { get; set; } = string.Empty;
        public int Health { get; set; }
        public int Radiation { get; set; }
        public int Damage { get; set; }
        public int ArmorValue { get; set; }
        public int FirstAid { get; set; }

        public int WeaponValue {  get; set; }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
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
    }
}
