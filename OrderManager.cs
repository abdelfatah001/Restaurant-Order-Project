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
        private static enServiceMethod CurrentOrderService = enServiceMethod.Null;

        // Change Service method
        public static void AssignServiceMethod(enServiceMethod serviceMethod = enServiceMethod.DineIn)
        {
            CurrentOrderService = serviceMethod;
        }

        // Order status of this current order
        private static enOrderStatus CurrentOrderStatus = enOrderStatus.enInProgress;

        public static void AssignOrderStatus(enOrderStatus OrderStatus = enOrderStatus.enDelivered)
        {
            CurrentOrderStatus = OrderStatus;
        }

        // The current order that contains all order items client ordered
        private static Order CurrentOrder = new Order();

        // Fill Current Order ( The whole order after finishing it)
        public static void StoreCurrentOrder()
        {
            if (CurrentOrderService == enServiceMethod.Null)
                AssignServiceMethod();

            
            CurrentOrder = new Order(OrderBuilder.CurrentOrderItemsList, OrderBuilder.TotalPrice, CurrentOrderService, CurrentOrderStatus);
        }


        // The List that contains all orders ordered
        public static List<Order> Orders = new List<Order>();

        
        // Store this finished current Order to Order List (it must be stored to database this function but i am not learnt the database yet may be later)
        public static void StoreCurrentOrderToOrdersList()
        {
            Orders.Add(CurrentOrder);
        }
    
    }
}
