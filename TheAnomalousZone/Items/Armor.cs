namespace TheAnomalousZone.Items
{
    internal class Armor : ItemBase
    {
        public int ArmorValue { get; set; }
        public Armor(int iD, string name, int price, int armorValue) : base(iD, name, price)
        {
            ArmorValue = armorValue;
        }
    }
}
