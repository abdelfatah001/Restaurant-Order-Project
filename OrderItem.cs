using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Wave_Priject
{
    class OrderItem
    {
        public  MenuItem Item  { get; }

        public byte ItemCount { get; set; }

        public OrderItem (MenuItem Item, byte ItemCount)
        {
            this.Item = Item;
            this.ItemCount = ItemCount;
        }
        public OrderItem()
        {
            
        }
    }
}
