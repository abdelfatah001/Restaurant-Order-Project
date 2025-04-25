using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wave_Priject
{
    class OrderManager
    {

        private OrderManager ()
        {

        }

        // Serivce Method of this current order
        public static enServiceMethod CurrentOrderService = enServiceMethod.Null;

        // Change Service method
        public static void AssignServiceMethod(enServiceMethod serviceMethod = enServiceMethod.DineIn)
        {
            CurrentOrderService = serviceMethod;
        }

        // Order status of this current order
        public static enOrderStatus CurrentOrderStatus = enOrderStatus.enInProgress;

        // The current order that contains all order items client ordered
        public static Order CurrentOrder = new Order();

        // Fill Current Order ( The whole order after finishing it)
        public static void StoreCurrentOrder()
        {
            if (CurrentOrderService == enServiceMethod.Null)
                AssignServiceMethod();

            
            CurrentOrder = new Order(OrderBuilder.CurrentOrderItemsList, OrderBuilder.TotalPrice, CurrentOrderService, CurrentOrderStatus);
        }


        // The List that contains all orders ordered
        public static List<Order> Orders = new List<Order>();

        // The List of All Orders To Show them in Managment Page
        public static List<OrderItem> CurrentOrderItems = new List<OrderItem>();
        // Store this finished current Order to Order List 
        public static void StoreCurrentOrderToOrderList()
        {
            Orders.Add(CurrentOrder);
        }
    
    }
}
