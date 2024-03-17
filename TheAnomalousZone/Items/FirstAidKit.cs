namespace TheAnomalousZone.Items
{
    public class FirstAidKit : ItemBase
    {
        public int AmountToHeal { get; set; }

        public FirstAidKit(int iD, string name, int amountToHeal, int price) : base(iD, name, price)
        {
            AmountToHeal = amountToHeal;
        }



    }
}
