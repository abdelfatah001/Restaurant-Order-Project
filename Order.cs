using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wave_Priject
{
    public enum enServiceMethod 
    { 
        Null = 0,
        DineIn = 1 ,
        TakeAway = 2, 
        Delivery = 3 
    };

    public enum enOrderStatus
    {
        Null = 0,
        enInProgress = 1, 
        enFinished = 2, 
        enDelivered = 3 
    };

    class Order
    {
        private int OrderID { get; }

        public List<OrderItem> OrderItems { get; set; }

        public DateTime OrderDateTime { get; set; }

        public int  TotalPrice { get; set; }

        // These Property me be add later now its by default = enServiceMethod.DineIn and can;t be changed by user
        public enServiceMethod OrderServiceMethod { get; set; }

        // These Property me be add later now its by default = enOrderStatus.enDelivered and can;t be changed by user
        public enOrderStatus OrderStatus { get; set; }


        public static short OrderCounts = 1;

        public Bill OrderBill { get; set; }


        public Order (List<OrderItem> orderItems,
            int totalPrice, enServiceMethod serviceMethod = enServiceMethod.DineIn, enOrderStatus orderStatus = enOrderStatus.enDelivered)
        {
            this.OrderID = 55 + OrderCounts; // the 55 is specified for order IDs
            this.OrderItems = orderItems;
            this.OrderDateTime = DateTime.Now;
            this.TotalPrice = totalPrice;   // make a variable nd by adding a new item += its price to it
            this.OrderServiceMethod = serviceMethod;
            this.OrderStatus = orderStatus;
            OrderCounts++;
            this.OrderBill = new Bill(orderItems, OrderDateTime, totalPrice, serviceMethod, orderStatus);
        }

        public Order()
        {
            
        }


    }
}
