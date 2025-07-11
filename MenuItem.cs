using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wave_Priject
{
    public class MenuItem
    {
        public byte ItemID { get; }

        public string ItemName { get; set; }

        public byte Price { get; set; }




        public int ItemCode;

        public MenuItem(byte ID, string Name, byte Price, int itemCode)
        {
            this.ItemID = ID;
            this.ItemName = Name;
            this.Price = Price;
            ItemCode = itemCode;
        }

        public MenuItem()
        {
            
        }

    }
}
