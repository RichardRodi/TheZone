namespace TheAnomalousZone.Items
{
    public class ItemBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int MinAmountToHeal { get; private set; }
        public int MaxAmountToHeal { get; private set; }

        public ItemBase(int iD, string name, int price, int minAmountToHeal, int maxAmountToHeal)
        {
            ID = iD;
            Name = name;
            Price = price;
            MinAmountToHeal = minAmountToHeal;
            MaxAmountToHeal = maxAmountToHeal;
        }

    }
}
