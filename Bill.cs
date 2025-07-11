using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wave_Priject
{
    class Bill
    {
        private int BillID { get; }

        public List<OrderItem> Items { get; set; }

        public DateTime DateTime { get; set; }

        public int TotalPrice { get; set; }

        public enServiceMethod OrderServiceMethod { get; set; }

        public enOrderStatus OrderStatus { get; set; }


        public static short BillCounts = 1;

        public Bill (List<OrderItem> items, DateTime dateTime, 
            int totalPrice, enServiceMethod orderServiceMethod, enOrderStatus orderStatus)
        {
            this.BillID = 45 + BillCounts; // the 45 is specified for bill IDs
            Items = items;
            DateTime = dateTime;
            TotalPrice = totalPrice;
            OrderServiceMethod = orderServiceMethod;
            OrderStatus = orderStatus;
            BillCounts++;
        }
    }
}
