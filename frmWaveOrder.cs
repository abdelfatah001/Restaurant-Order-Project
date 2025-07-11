using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Wave_Priject
{
    public partial class frmWaveOrder : Form
    {
        public frmWaveOrder()
        {
            InitializeComponent();
            SetTags();
        }

        private void SetTags ()
        {

            // For Pizza Menu Items
            this.rbMargheritaPizza.Tag = new ItemRadioButtonTag("111");
            this.rbPepperoniPizza.Tag = new ItemRadioButtonTag("112");
            this.rbBBQChickenPizza.Tag = new ItemRadioButtonTag("113");

            // For Burger Menu Items
            this.rbCheeseburger.Tag = new ItemRadioButtonTag("121");
            this.rbMushroomBurger.Tag = new ItemRadioButtonTag("122");
            this.rbChickenBurger.Tag = new ItemRadioButtonTag("123");

            // For Chicken Menu Items
            this.rbGrilledChicken.Tag = new ItemRadioButtonTag("131");
            this.rbChickenTikka.Tag = new ItemRadioButtonTag("132");

            // For Meat Menu Items
            this.rbSteak.Tag = new ItemRadioButtonTag("141");
            this.rbLambChops.Tag = new ItemRadioButtonTag("142");
            this.rbBeefKofta.Tag = new ItemRadioButtonTag("143");
            this.rbBuffaloWings.Tag = new ItemRadioButtonTag("144");

            // For Dessert Menu Items
            this.rbChocolateLavaCake.Tag = new ItemRadioButtonTag("211");
            this.rbBlackForestCake.Tag = new ItemRadioButtonTag("212");

            // For Ice Cream Menu Items
            this.rbVanillaIceCream.Tag = new ItemRadioButtonTag("221");
            this.rbChocolateIceCream.Tag = new ItemRadioButtonTag("222");
            this.rbStrawberryIceCream.Tag = new ItemRadioButtonTag("223");

            // For Apple Pie Menu Items
            this.rbClassicApplePie.Tag = new ItemRadioButtonTag("231");
            this.rbDutchApplePie.Tag = new ItemRadioButtonTag("232");
            this.rbCaramelApplePie.Tag = new ItemRadioButtonTag("233");

            // For Donut Menu Items
            this.rbGlazeDonut.Tag = new ItemRadioButtonTag("241");
            this.rbCinnamonDonut.Tag = new ItemRadioButtonTag("242");

            // For Juices Menu Items
            this.rbMango.Tag = new ItemRadioButtonTag("311");
            this.rbStrawberry.Tag = new ItemRadioButtonTag("312");
            this.rbOrange.Tag = new ItemRadioButtonTag("313");
            this.rbPineApple.Tag = new ItemRadioButtonTag("314");
            this.rbLemon.Tag = new ItemRadioButtonTag("315");

            // For Cola Menu Items
            this.rbSevenUp.Tag = new ItemRadioButtonTag("321");
            this.rbCokaCola.Tag = new ItemRadioButtonTag("322");
            this.rbschweppes.Tag = new ItemRadioButtonTag("323");

            // For Hot Drinks Menu Items
            this.rbIcedCoffee.Tag = new ItemRadioButtonTag("331");
            this.rbIcedTea.Tag = new ItemRadioButtonTag("332");

            // For Coffee Menu Items
            this.rbTurkishCoffee.Tag = new ItemRadioButtonTag("411");
            this.rbFrenchCoffee.Tag = new ItemRadioButtonTag("412");
            this.rbEspresso.Tag = new ItemRadioButtonTag("413");
            this.rbCappuccino.Tag = new ItemRadioButtonTag("414");
            this.rbLatte.Tag = new ItemRadioButtonTag("415");
            this.rbMocha.Tag = new ItemRadioButtonTag("416");

            // For Tea Menu Items
            this.rbPlainTea.Tag = new ItemRadioButtonTag("421");
            this.rbTeawMilk.Tag = new ItemRadioButtonTag("422");
            this.rbGreenTea.Tag = new ItemRadioButtonTag("423");

            // For Hot Chocolate Menu Item
            this.rbHotChocolate.Tag = new ItemRadioButtonTag("431");


        }


        private void frmWaveOrder_FormClosed(object sender, FormClosedEventArgs e) // to close login form with it
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Close();  // Close the frmWave form
            }
        }

        private void frmWaveOrder_Load(object sender, EventArgs e) // to load items and sections in Menus
        {
            

            rbEat.Checked = true;

            // Load all Menus and menus section and menus items to their lists (Build the dataStructure)
            DataStore.AddSectionsToMenusLists();
            DataStore.AddItemToSectionsLists();
            MenusManager.FillMenusList();
        }

        // Close Program by escape button of keyboard
        private void frmWaveOrder_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }


        // switch between Eat and Drink Menus
        private void rbEat_CheckedChanged(object sender, EventArgs e)
        {

            if (rbEat.Checked == true)
            {
                pnlColdDrinkies.Visible = false;
                pnlHotDrinkies.Visible = false;
                pnlDessertFood.Visible = true;
                pnlMainFood.Visible = true;

                pnlColdDrinkies.Enabled = false;
                pnlHotDrinkies.Enabled = false;
                pnlDessertFood.Enabled = true;
                pnlMainFood.Enabled = true;

                pnlColdDrinkies.BringToFront();
            }
        }

        private void rbDrink_CheckedChanged(object sender, EventArgs e)
        {

            if (rbDrink.Checked == true)
            {
                pnlDessertFood.Visible = false;
                pnlMainFood.Visible = false;
                pnlColdDrinkies.Visible = true;
                pnlHotDrinkies.Visible = true;

                pnlDessertFood.Enabled = false;
                pnlMainFood.Enabled = false;
                pnlColdDrinkies.Enabled = true;
                pnlHotDrinkies.Enabled = true;


                pnlHotDrinkies.BringToFront();

            }
        }


        private RadioButton PreviousRadioButton = null;


        // Radio button of Current item
        // assigned when click on radio button event
        // used to access of its Tag to check its existence in current order if Tag[3] == '.' not existed else it carry its index
        private RadioButton CurrentItemRB;

        // this i will use it to store last item panel index of flp in its last character of its tag
        // intialized with -1 to when add first item it increases and become 0
        // used to define each panel its index by storing it in its tag
        private static short ItemIndex = -1;


        // The event of checking ane unchecking radioButtons
        private void ChangeAnItem(object sender, EventArgs e)
        {   // there are two paths the rb Checking state will reserve by firing this event
            //in case of it was unchecked and checked by firing the event go to first path (if block)
            // in the other case go to second path (else block)
            CurrentItemRB = (RadioButton)sender;

            ItemRadioButtonTag itemRadioButtonTag = (ItemRadioButtonTag)CurrentItemRB.Tag;



            if (CurrentItemRB.Checked)
            {
                if (PreviousRadioButton != null)
                { // this when fire CheckedChanged event it enter to the else block that is empty so nothing happens
                    UncheckPreviousRadioButton();
                }

                // update assigning of Previous radio button
                PreviousRadioButton = CurrentItemRB;



                // reset CurrentMenuItem and CurrentOrderItem and Quantity of CurrentMenuItem
                OrderBuilder.ResetItem();


                OrderBuilder.StoreCurrentMenuItem(itemRadioButtonTag.ItemCode);
                // change showing data of chosen item (CurrentMenuItem)
                ChangeChosenItem();
            }

            else
            {
                // it enters the empty code in case of unchecking the radio button to don't excute the same code of checking the radio button
            }

        }


        private void btnFoodAddToOrder_Click(object sender, EventArgs e)
        {
            if (lblChoosenName.Text == "") // if no selected item
                return;


            // Assign the count of the item to NumOfCurrentItem t
            OrderBuilder.QtyOfCurrentItem = (byte)int.Parse(numItemCount.Value.ToString());

            ItemRadioButtonTag itemRadioButtonTag = (ItemRadioButtonTag)CurrentItemRB.Tag;


            if (!itemRadioButtonTag.IsExist)
            { // if its first use of the item
                // add the chosen item to order item list and update total price


                // Add another panel item increase the index
                ItemIndex++;

                // first store data in it (Current Order Item) to convert current MenuItem to Current OrderItem 
                OrderBuilder.StoreOrderItem();

                // Assigning OrderItemIndex In CurrentOrderItem After Storing CurrentMenuItem to CurrentOrderItem
                // and before Adding CurrentOrderItem to CurrentOrderList
                OrderBuilder.CurrentOrderItem.IndexInCurrentOrderList = ItemIndex;

                // Add CurrentOrderItem to CurrentOrderItemsList and UpdatePrice
                OrderBuilder.AddCurrentOrderItemToOrderItemsList();

                // add new panel for new item and update radio button tag data and Update TotalPrice on screen
                ShowOrderItem();
            }

            else
            {
                MessageBox.Show("this Item already existed");
            }

            // reset stored and shown data about the item that already have added to current order list steading for new item 
            OrderBuilder.ResetItem(); // stored data 
            ResetCurrentItemDetails(numItemCount, lblPrice, lblChoosenName); // shown data
        }


        private void ShowOrderItem()
        {
            // Make a panel for an item
            Panel itemPanel = MakeAnItemPanel();

            // Make labels for item name and count and price (lblName)(lblCount)(lbPrice)
            GenerateThisItemPanelControls(itemPanel);

            // Add each item (panel) in the flow layout panels
            flpShowOrder.Controls.Add(itemPanel);

            // adding item panel and index of item order of Current order list in radio button tag
            ItemRadioButtonTag.StoreRadioButtonData(itemPanel, CurrentItemRB, ItemIndex);

            // update total price from total price variable that updated by AddCurrentOrderItemToOrderItemsList()
            lblTotalPrice.Text = OrderBuilder.TotalPrice.ToString();
        }

        private Panel MakeAnItemPanel()
        {
            // Make a panel for an item (itemPanel)
            Panel itemPanel = new Panel();
            itemPanel.Width = flpShowOrder.Width - 9;
            itemPanel.BackColor = Color.Beige;
            itemPanel.Height = 25;
            itemPanel.Margin = new Padding(0, 2, 0, 0); // make an external distance between each panel of an item
            ItemPanelTag panelTag = new ItemPanelTag(false, CurrentItemRB);
            itemPanel.Tag = panelTag;
            itemPanel.MouseDown += ItemPanel_Click;
            return itemPanel;
        }
        public void GenerateThisItemPanelControls(Panel itemPanel)
        {
            // Make lables for item name and count and price (lblName)(lblCount)(lbPrice)
            Label lblName = new Label()
            {
                Text = " " + OrderBuilder.CurrentOrderItem.Item.ItemName,
                Width = (int)(itemPanel.Width * 0.6),
                Location = new Point(0, 3),
                Font = new Font("Franklin Gothic", 12, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft,
            };
            lblName.MouseDown += ItemPanel_Click;  // make labels fire the same click event of the item panel

            Label lblCount = new Label()
            {
                Text = OrderBuilder.CurrentOrderItem.ItemCount.ToString(),
                Width = (int)(itemPanel.Width * 0.2),
                Location = new Point((int)(itemPanel.Width * 0.6), 3),
                Font = new Font("Franklin Gothic", 12, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter
            };
            lblCount.MouseDown += ItemPanel_Click;

            Label lbPrice = new Label()
            {
                Text = (OrderBuilder.CurrentOrderItem.Item.Price * OrderBuilder.CurrentOrderItem.ItemCount).ToString(),
                Width = (int)(itemPanel.Width * 0.2),
                Location = new Point((int)(itemPanel.Width * 0.8), 3),
                Font = new Font("Franklin Gothic", 12, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter
            };
            lbPrice.MouseDown += ItemPanel_Click;

            Button btnDelete = new Button()
            {
                Text = "Delete",
                Width = (int)(itemPanel.Width * 0.25),
                Height = 30,
                Location = new Point(95, 33),
            };
            btnDelete.Click += btnDelete_Click;

            NumericUpDown numNewQty = new NumericUpDown()
            {
                Width = (int)(itemPanel.Width * 0.1),
                Height = 30,
                Location = new Point(190, 38),
                Value = 1,
                Minimum = 1,
                Maximum = 10
            };


            // Add labels to item panels
            AddThisControlsToItemPanel(itemPanel, lblName, lblCount, lbPrice, btnDelete, numNewQty);
        }
        public void AddThisControlsToItemPanel(Panel itemPanel, Label lblName, Label lblCount, Label lbPrice, Button btnDelete, NumericUpDown numNewQty)
        {
            itemPanel.Controls.Add(lblName);
            itemPanel.Controls.Add(lblCount);
            itemPanel.Controls.Add(lbPrice);
            itemPanel.Controls.Add(btnDelete);
            itemPanel.Controls.Add(numNewQty);
        }
        
        private void ItemPanel_Click(object sender, EventArgs e)
        {// Expand and Shrink of Item Panel Tag to show editing controls
        
            // UncheckPreviousRadioButton();
            Panel itemPnl;

            if (sender is Label lbl) // if sender is the panel children store its parent panel (itemPanel)
                itemPnl = lbl.Parent as Panel;

            else // if it the parent panel itself store it
                itemPnl = (Panel)sender;


            byte OldCount = byte.Parse(itemPnl.Controls[1].Text);

            ItemPanelTag itemPanelTag = (ItemPanelTag)itemPnl.Tag;

            // Item Panel Index in flpOrder is tag without its last character
            short ItemPanelIndex = ((ItemRadioButtonTag)itemPanelTag.ItemRB.Tag).Index;

            // Panel tag state opened or close 
            // closed if it 0 number (default) opened if it 1 number
            bool PanelState = itemPanelTag.IsOpened;


            // MessageBox.Show(ItemPanelIndex.ToString()); // this for debugging

            if (!PanelState) // if it closed open it
            {
                itemPnl.Height += 45;
            }



            else // if it opened close it (1)
            { 
                if (byte.Parse(itemPnl.Controls[4].Text) != OldCount)
                {
                    EditQuantity(itemPnl, itemPanelTag);
                }
                itemPnl.Height = 25;
            }

            UpdateItemPanelTag(ref itemPnl);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            Button btnDelete = (Button)sender;


            // get the parent itempanel of this delet button to be known which item must deleted
            Panel PnlParent = btnDelete.Parent as Panel;

            // get itemPanelTag which everything about item Stored 
            ItemPanelTag itemPanelTag = (ItemPanelTag)PnlParent.Tag;

            ItemRadioButtonTag itemRadioButtonTag = ((ItemRadioButtonTag)itemPanelTag.ItemRB.Tag);

            OrderBuilder.DeleteItemFromCurrentOrderList(itemRadioButtonTag.Index);

            DeleteItemFromScreen(itemPanelTag.ItemRB);


            // Decrease one from ItemPanelIndex because one item was deleted
            frmWaveOrder.ItemIndex--;

        }

        private void EditQuantity(Panel itemPanel, ItemPanelTag itemPanelTag)
        {

            // get item to edit quantity from ItemRadioButton in ItemPanel
            short Index = ((ItemRadioButtonTag)((ItemPanelTag)itemPanel.Tag).ItemRB.Tag).Index;

            // get new Quantity from Numeric Up Down control in itemPanel
            short NewQuantity = short.Parse(itemPanel.Controls[4].Text.ToString());

            // Edit the Quantity of the Item in CurrentOrderItemList
            OrderBuilder.EditQuantityOfThisItem(NewQuantity, Index);


            UpdateThisItemOnScreen(itemPanel, Index);

            MessageBox.Show("Updated");
        }


        private void ModifyThisItemPanelTagIndex(Panel pnl)
        {
            ItemPanelTag panelTag = pnl.Tag as ItemPanelTag;

            ((ItemRadioButtonTag)panelTag.ItemRB.Tag).Index--;
            RadioButton panelRb = (RadioButton)panelTag.ItemRB;
            if (panelRb != null && panelRb.Tag is ItemRadioButtonTag rbTag)
            {
                rbTag.Index--;
            }
        }
        private void ModifyNextItemsPanelTagIndex(short DeletedItemIndex)
        {
            // MessageBox.Show("Modifing");// for debugging  
            for (int i = DeletedItemIndex; i < flpShowOrder.Controls.Count; i++)
            {
                ModifyThisItemPanelTagIndex((Panel)flpShowOrder.Controls[i]);
            }
        }
        private void DeleteExistenceOfRadioButtonTag(RadioButton rb)
        {
            ((ItemRadioButtonTag)rb.Tag).IsExist = false;
            ((ItemRadioButtonTag)rb.Tag).Index = -1;
        }
        private void DeleteItemFromScreen (RadioButton ItemRadioButton)
        {
            ItemRadioButtonTag itemRadioButtonTag = ((ItemRadioButtonTag)ItemRadioButton.Tag);

            flpShowOrder.Controls.RemoveAt(itemRadioButtonTag.Index);

            // modify next panels indexes stored in their tags because by deleting not last item it disturb the indexes sequence
            if (itemRadioButtonTag.Index < flpShowOrder.Controls.Count)
                ModifyNextItemsPanelTagIndex(itemRadioButtonTag.Index);


            DeleteExistenceOfRadioButtonTag(ItemRadioButton);
            lblTotalPrice.Text = OrderBuilder.TotalPrice.ToString();

        }
        
       
        private void UpdateItemPanelTag(ref Panel pnl)
        {
            ItemPanelTag itempnlTag = (ItemPanelTag)pnl.Tag;

            itempnlTag.IsOpened = (itempnlTag.IsOpened) ? false : true; // change its state if opened to closed and vice versa

            pnl.Tag = itempnlTag;

        }
        private void UpdateThisItemOnScreen (Panel itemPanel, short Index)
        {// update the item quantity and price in the item Panel


            // Update Item Quantity on Screen  (ItemPanel (Quantity Label))
            itemPanel.Controls[1].Text = OrderBuilder.CurrentOrderItemsList.ElementAt(Index).ItemCount.ToString();

            // Update Item Price on Screen  (ItemPanel (Price Label))
            itemPanel.Controls[2].Text = OrderBuilder.CurrentOrderItemsList.ElementAt(Index).Price.ToString();

            //  Update shown total price to be equal to store total price (OrderBuilder.TotalPrice)
            lblTotalPrice.Text = OrderBuilder.TotalPrice.ToString();
        }
        private void ChangeChosenItem()
        {
            lblPrice.Text = OrderBuilder.CurrentMenuItem.Price.ToString();
            lblChoosenName.Text = OrderBuilder.CurrentMenuItem.ItemName;
        }
        private void UncheckPreviousRadioButton()
        { // used two times  1. when changed radio button without adding it to order
            // 2. after adding it to order steading for new item

            PreviousRadioButton.Checked = false;
            PreviousRadioButton = null;
            OrderBuilder.CurrentMenuItem = null;
        }
        private void ResetCurrentItemDetails(NumericUpDown numItemCount, Label lblPrice, Label lblChoosenName)
        {
            numItemCount.Value = 1;
            lblPrice.Text = "0";
            lblChoosenName.Text = "";
            UncheckPreviousRadioButton();
        }


        private void ResetOrderSummaryScreen ()
        {
            flpShowOrder.Controls.Clear();
            lblTotalPrice.Text ="0" ;
            lblPrice.Text = "0";
        }


        private void DeMarkThisItemExistence(RadioButton rb)
        {
            ((ItemRadioButtonTag)rb.Tag).IsExist = false;
        }
        private void DeMarkItemsExistenceFromRadioButtons()
        {
            for (short i = 0; i < flpShowOrder.Controls.Count; i++)
            {
                RadioButton rb = ((ItemPanelTag)flpShowOrder.Controls[i].Tag).ItemRB;
                DeMarkThisItemExistence(rb);
            }
        }

        private void ResetItemIndex ()
        {
            // Reset ItemIndex when order finished
            // if it not resetted this result in mistake of indexing OrderItem of the new order list cuz it depend on it
            ItemIndex = -1;
        }

        private void btnFoodOrder_Click(object sender, EventArgs e)
        {
            if (OrderBuilder.CurrentOrderItemsList.Count == 0)
                return;

            Form frm = new frmOrderShow();
            frm.Show();

            ResetItemIndex();

            DeMarkItemsExistenceFromRadioButtons();
            ResetOrderSummaryScreen();

        }

        private void lblChoosenName_Click(object sender, EventArgs e)
        {

        }
    }
}




        


