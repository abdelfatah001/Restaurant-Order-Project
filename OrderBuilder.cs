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
        public static int TotalPrice = 0;


        // This is the current menu item that client choose (MenuItem)
        public static MenuItem CurrentMenuItem = new MenuItem(0, "Null", 0, 0);

        // Quantity of CurrentMenuItem which with Current MenuItem make CurrentOrderItem
        public static byte QtyOfCurrentItem = 1;

        // This is the current order item that client choose after select the count (OrderItem)
        public static OrderItem CurrentOrderItem = new OrderItem();


        // This List contains all order items of this Order.
        public static List<OrderItem> CurrentOrderItemsList = new List<OrderItem>();


        // Store current menu item in CurrentMenuItem by analyzing item code present in its radio button to access the item 
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
        }
      
        // Add Current Order Item to the list of current order items. 
        public static void AddCurrentOrderItemToOrderItemsList()
        { 
            
            // Add (Current Order Item) to (Current Order Items List)
            CurrentOrderItemsList.Add(CurrentOrderItem);

            // Update total price by adding this item price
            TotalPrice += (short)(CurrentOrderItem.ItemCount * CurrentOrderItem.Item.Price);
        }

       


        public static void DeleteItemFromCurrentOrderList (short index)
        {
            if (index < 0 || index >= CurrentOrderItemsList.Count)
            {
                return;
            }
            // store item to delete price to substract it from total price
            int ItemToDeletePrice = CurrentOrderItemsList.ElementAt(index).Price;

            // Remove item from CurrentOrderList
            CurrentOrderItemsList.RemoveAt(index);

            // Substract the price of deleted item from total price
            TotalPrice -= ItemToDeletePrice;

        }
 
        public static void EditQuantityOfThisItem (short NewQuantity, short Index)
        {
            // Substract the the old Item Price that before update item quantity from TotalPrice
            TotalPrice -= CurrentOrderItemsList.ElementAt(Index).Price;

            // Update Quantity of the item
            CurrentOrderItemsList.ElementAt(Index).ItemCount = (byte) NewQuantity;

            // Update the Price of the Item accordeing to the new quantity
            CurrentOrderItemsList.ElementAt(Index).Price = (int)(NewQuantity * CurrentOrderItemsList.ElementAt(Index).Item.Price);

            // Add new price of the item after update its quantity to Total Price 
            TotalPrice += CurrentOrderItemsList.ElementAt(Index).Price;
        }

        public static void ResetItem()
        { // Reset MenuItem, Count, OrderItem
          // used to reset item stored data when already it added to Current Order Items List steading for new item

            QtyOfCurrentItem = 1;
            CurrentMenuItem = new MenuItem(0, "Null", 0, 0);
            CurrentOrderItem = new OrderItem();
        }


        public static void ResetCurrentOrderList ()
        {
            CurrentOrderItemsList.Clear();
        }
    }
}
