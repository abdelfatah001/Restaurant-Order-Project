using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wave_Priject
{
    class OrderBuilder
    {
        private OrderBuilder ()
        {

        }

        // store the total price after adding any item to the order.
        // changed by AddCurrentOrderItemToOrderItemsList.
        public static short TotalPrice = 0;


        // This is the current menu item that client choose (MenuItem)
        public static MenuItem CurrentMenuItem = new MenuItem(0, "Null", 0, 0);

        // Quantity of CurrentMenuItem which with Current MenuItem make CurrentOrderItem
        public static byte QtyOfCurrentItem = 1;

        // This is the current order item that client choose after select the count (OrderItem)
        public static OrderItem CurrentOrderItem = new OrderItem();


        // This List contains all order items of this Order.
        public static List<OrderItem> CurrentOrderItemsList = new List<OrderItem>();


        // Store current menu item in CurrentMenuItem
        public static void StoreCurrentMenuItem(string ItemCode)
        {


            if (ItemCode.Length != 3)
            {
                MessageBox.Show("Invalid ItemCode: " + ItemCode);
                return; // or handle accordingly
            }

            // De code Item code which in radio buttons tags
            byte MenuIndex = (byte)(int.Parse(ItemCode[0].ToString()) - 1);
            byte sectionIndex = (byte)(int.Parse(ItemCode[1].ToString()) - 1);
            byte itemIndex = (byte)(int.Parse(ItemCode[2].ToString()) - 1);

            if (MenusManager.IsItemCodeOutOfTheMenusRange(MenuIndex, sectionIndex, itemIndex))
            {
                MessageBox.Show("Put of the range");
                return;
            }    
                

            MenuItem item =  MenusManager.RestaurantMenus.ElementAt(MenuIndex).Sections.ElementAt(sectionIndex).Items.ElementAt(itemIndex);         

            // Assign value in CurrentMenuItem
            CurrentMenuItem = item;
        }

        // Store current menu item (CurrentMenuItem) and Quantity of it (QtyOfCurrentItem) in CurrentMenuItem
        public static void StoreOrderItem()
        { 
            // Store Order Item with MenuItem and this item number
            CurrentOrderItem = new OrderItem(CurrentMenuItem, QtyOfCurrentItem);
            
            // Update total price by adding this item price
            TotalPrice += (short)(CurrentOrderItem.ItemCount * CurrentOrderItem.Item.Price);
        }
      
        // Add Current Order Item to the list of current order items. 
        public static void AddCurrentOrderItemToOrderItemsList()
        { 
            // first store data in it (Current Order Item) to convert current MenuItem to Current OrderItem 
            StoreOrderItem(); 
            
            // Add (Current Order Item) to (Current Order Items List)
            CurrentOrderItemsList.Add(CurrentOrderItem);
        }

        
        public static void ResetItem()
        { // Reset MenuItem, Count, OrderItem
          // used to reset item stored data when already it added to Current Order Items List steading for new item

            QtyOfCurrentItem = 1;
            CurrentMenuItem = new MenuItem(0, "Null", 0, 0);
            CurrentOrderItem = new OrderItem();
        }


     
        public static void EditQtyInListWhenReplicated (short index)
        { 
            // edit on its quantity in Current Order List
            OrderBuilder.CurrentOrderItemsList.ElementAt(index).ItemCount += OrderBuilder.CurrentOrderItem.ItemCount;
        }


        public static void DeleteItemFromCurrentOrderList (short index)
        {
            if (index < 0 || index >= CurrentOrderItemsList.Count)
            {
                return;
            }

            CurrentOrderItemsList.RemoveAt(index);

        }

    }
}
