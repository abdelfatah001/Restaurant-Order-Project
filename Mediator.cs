using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wave_Priject
{
    class Mediator
    {
        private Mediator ()
        {

        }

        private void ChangeChosenItem()
        {
            frmWaveOrder.lblPrice.Text = OrderBuilder.CurrentMenuItem.Price.ToString();
            frmWaveOrder.lblChoosenName.Text = OrderBuilder.CurrentMenuItem.ItemName;
        }

        private void ModifyThisItemPanelTagIndex(Panel pnl)
        {
            ItemPanelTag panelTag = pnl.Tag as ItemPanelTag;

            panelTag.flpInedx--;
            RadioButton panelRb = (RadioButton)panelTag.rb;
            if (panelRb != null && panelRb.Tag is ItemRadioButtonTag rbTag)
            {
                rbTag.Index--;
            }
        }

        private void ModifyNextItemsPanelTagIndex(short DeletedItem)
        {
            // MessageBox.Show("Modifing");// for debugging  
            for (int i = DeletedItem; i < frmWaveOrder.flpShowOrder.Controls.Count; i++)
            {
                ModifyThisItemPanelTagIndex((Panel)frmWaveOrder.flpShowOrder.Controls[i]);
            }
        }

        private void DeleteExistenceOfRadioButtonTag(RadioButton rb)
        {
            ((ItemRadioButtonTag)rb.Tag).IsExist = false;
            ((ItemRadioButtonTag)rb.Tag).Index = -1;
        }

        public static void btnDelete_Click(object sender, EventArgs e)
        {

            Button btnDelete = (Button)sender;

            Panel PnlParent = btnDelete.Parent as Panel;


            ItemPanelTag itemPanelTag = (ItemPanelTag)PnlParent.Tag;

            OrderBuilder.DeleteItemFromCurrentOrderList(itemPanelTag.flpInedx);

            frmWaveOrder.flpShowOrder.Controls.RemoveAt(itemPanelTag.flpInedx);

            // modify next panels indexes stored in their tags because by deleting not last item it disturb the indexes sequence
            if (itemPanelTag.flpInedx < frmWaveOrder.flpShowOrder.Controls.Count)
                ModifyNextItemsPanelTagIndex(itemPanelTag.flpInedx);

            DeleteExistenceOfRadioButtonTag(itemPanelTag.rb);

            // Decrease one from ItemPanelIndex because one item was deleted
            frmWaveOrder.ItemPanelIndex--;

            OrderBuilder.TotalPrice -= (byte.Parse(PnlParent.Controls[2].Text));
            frmWaveOrder.lblTotalPrice.Text = OrderBuilder.TotalPrice.ToString();
        }

        public static void UpdateItemPanelTag(ref Panel pnl)
        {
            ItemPanelTag itempnlTag = (ItemPanelTag)pnl.Tag;

            itempnlTag.IsOpened = (itempnlTag.IsOpened) ? false : true; // change its state if opened to closed and vice versa

            pnl.Tag = itempnlTag;

        }

        private static void EditQuantity(Panel itemPanel, ItemPanelTag itemPanelTag)
        {
            if (int.Parse(itemPanel.Controls[4].Text) == 0 || int.Parse(itemPanel.Controls[4].Text) >= 10)
            {
                byte Num = byte.Parse(itemPanel.Controls[1].Text);
                itemPanel.Controls[4].Text = Num.ToString();
                return;
            }

            //MessageBox.Show("Check Passed");

            // edit count of item in current order list to be equal what in num up and down control
            OrderBuilder.CurrentOrderItemsList.ElementAt(itemPanelTag.flpInedx).ItemCount = byte.Parse(itemPanel.Controls[4].Text);



            // MessageBox.Show("Item count updated in the vector");

            // the old price on price label before editing

            short Price = short.Parse(itemPanel.Controls[2].Text);

            // Delete the old price attached to old quantity
            OrderBuilder.TotalPrice -= Price;


            // edit shown count of item panel (count label) to be equal to what in num up and down control
            itemPanel.Controls[1].Text = itemPanel.Controls[4].Text;

            // price after editing item quantity equal to multiply of item price * its count
            short EditedPrice = (short)(((OrderBuilder.CurrentOrderItemsList.ElementAt(itemPanelTag.flpInedx).ItemCount)
                * (OrderBuilder.CurrentOrderItemsList.ElementAt(itemPanelTag.flpInedx).Item.Price)));

            // Add to total price the item price after editing quantity 
            OrderBuilder.TotalPrice += EditedPrice;

            //  itemPnl.Controls[2].Text = .ToString();
            itemPanel.Controls[2].Text = EditedPrice.ToString();

            //  Update shown total price to be equal to store total price (OrderBuilder.TotalPrice)
            frmWaveOrder.lblTotalPrice.Text = OrderBuilder.TotalPrice.ToString();

            // MessageBox.Show("Updated");
        }


        // Expand and Shrink of Item Panel Tag to show editing controls
        private static void ItemPanel_Click(object sender, EventArgs e)
        {

            // UncheckPreviousRadioButton();
            Panel itemPnl;



            if (sender is Label lbl) // if sender is the panel children store its parent panel (itemPanel)
                itemPnl = lbl.Parent as Panel;

            else // if it the parent panel itself store it
                itemPnl = (Panel)sender;


            byte OldCount = byte.Parse(itemPnl.Controls[1].Text);

            ItemPanelTag itemPanelTag = (ItemPanelTag)itemPnl.Tag;

            // Item Panel Index in flpOrder is tag without its last character
            short ItemPanelIndex = itemPanelTag.flpInedx;

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

        public static void GenerateThisItemPanelControls(Panel itemPanel)
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
                Maximum = 10
            };
            // Add labels to item panels
            AddThisControlsToItemPanel(itemPanel, lblName, lblCount, lbPrice, btnDelete, numNewQty);
        }

        private static void AddThisControlsToItemPanel(Panel itemPanel, Label lblName, Label lblCount, Label lbPrice, Button btnDelete, NumericUpDown numNewQty)
        {
            itemPanel.Controls.Add(lblName);
            itemPanel.Controls.Add(lblCount);
            itemPanel.Controls.Add(lbPrice);
            itemPanel.Controls.Add(btnDelete);
            itemPanel.Controls.Add(numNewQty);
        }


    }
}
