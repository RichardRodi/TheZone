using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAnomalousZone.Items
{
    public class ItemBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int AmountToHeal {  get; set; }

        public ItemBase(int iD, string name, int price, int amountToHeal)
        {
            ID = iD;
            Name = name;
            Price = price;
            AmountToHeal = amountToHeal;
        }

    }
}
