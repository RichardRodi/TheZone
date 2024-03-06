namespace TheZone.Base
{
    public abstract class BaseEnemy : BaseCharacter
    {
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
        public int ArmorValue { get; set; }
        public int StartingHealth { get; set; }
        public int RadiationDamage { get; set; }
        public int Speed {  get; set; }
    }
}
