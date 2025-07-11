using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wave_Priject
{
    public partial class frmOrderShow: Form
    {
        public frmOrderShow()
        {
            InitializeComponent();
            IntializeThisComponents();

        }
        private void IntializeThisComponents()
        { // cuz they are not intialized and i don't know why

            this.lblTotalPrice.Size = new Size(94, 30);
            this.lblTotalPrice.Location = new Point(206, 393);
            this.lblTotalPrice.Font = new System.Drawing.Font("Noto Sans HK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.label1.Font = new System.Drawing.Font("Noto Sans HK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new Size(121, 30);
            this.label1.Text = "Total Price";
            this.label1.Location = new Point(70, 393);

        }

        private Panel MakeAnItemPanel ()
        {
            Panel itemPanel = new Panel()
            {
                Width = flpOrderReview.Width - 5,
                Height = 33,
                Margin = new Padding(2, 2, 2, 2),
                BackColor = Color.FromArgb(204, 209, 217)
            };
            itemPanel.MouseDown += ItemPanelExpand;

            return itemPanel;
        }


        public void GenerateThisItemPanelControls(Panel itemPanel, OrderItem orderItem)
        {
            // Make lables for item name and count and price (lblName)(lblCount)(lbPrice)
            Label lblName = new Label()
            {
                Text = " " + orderItem.Item.ItemName,
                Width = (int)(itemPanel.Width * 0.5),
                Location = new Point(0, 3),
                Font = new Font("Franklin Gothic", 12, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft,
            };
            lblName.MouseDown += ItemPanelExpand;

            Label lblCount = new Label()
            {
                Text = orderItem.ItemCount.ToString(),
                Width = (int)(itemPanel.Width * 0.25),
                Location = new Point((int)(itemPanel.Width * 0.6), 3),
                Font = new Font("Franklin Gothic", 12, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter
            };
            lblCount.MouseDown += ItemPanelExpand;

            Label lbPrice = new Label()
            {
                Text = (orderItem.Item.Price * orderItem.ItemCount).ToString(),
                Width = (int)(itemPanel.Width * 0.25),
                Location = new Point((int)(itemPanel.Width * 0.8), 3),
                Font = new Font("Franklin Gothic", 12, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter
            };
            lbPrice.MouseDown += ItemPanelExpand;

            Button btnDelete = new Button()
            {
                Text = "Delete",
                Width = (int)(itemPanel.Width * 0.2),
                Height = 27,
                Location = new Point(110, 33),
            };
            btnDelete.Click += btnDelete_Click;

            NumericUpDown numNewQty = new NumericUpDown()
            {
                Width = (int)(itemPanel.Width * 0.1),
                Height = 30,
                Location = new Point(205, 37),
                Value = 1,
                Minimum = 1,
                Maximum = 10
            };


            // Add labels to item panels
            AddThisControlsToItemPanel(itemPanel, lblName, lblCount, lbPrice, btnDelete, numNewQty);
        }

        private void AddThisControlsToItemPanel(Panel itemPanel, Label lblName, Label lblCount, Label lbPrice, Button btnDelete, NumericUpDown numNewQty)
        {
            itemPanel.Controls.Add(lblName);
            itemPanel.Controls.Add(lblCount);
            itemPanel.Controls.Add(lbPrice);
            itemPanel.Controls.Add(btnDelete);
            itemPanel.Controls.Add(numNewQty);
        }

        private void ModifyNextItemsPanelTagIndex(short DeletedItemIndex)
        {
            // MessageBox.Show("Modifing");// for debugging  
            for (int i = DeletedItemIndex; i < flpOrderReview.Controls.Count; i++)
            {
                int OldIndex = ((ItemPanelTag)flpOrderReview.Controls[i].Tag).Index;
                ((ItemPanelTag)flpOrderReview.Controls[i].Tag).Index = (short) (OldIndex - 1);
            }
        }

        private void ItemPanelExpand (object sender, EventArgs e)
        {
            Panel itemPnl;

            if (sender is Label lbl) // if sender is the panel children store its parent panel (itemPanel)
                itemPnl = lbl.Parent as Panel;

            else // if it the parent panel itself store it
                itemPnl = (Panel)sender;

            bool IsOpened = ((ItemPanelTag)itemPnl.Tag).IsOpened;
            byte OldQty = byte.Parse(itemPnl.Controls[1].Text);


            short Index = ((ItemPanelTag)itemPnl.Tag).Index;


            if (!IsOpened)
            {
                itemPnl.Height += 40;

                // make the numeric up and down = the quantity of the item
                itemPnl.Controls[4].Text = OrderBuilder.CurrentOrderItemsList[Index].ItemCount.ToString();

                ((ItemPanelTag)itemPnl.Tag).IsOpened = true;
            }

            else // if it opened close it (1)
            {
                short NewQty = short.Parse(itemPnl.Controls[4].Text);

                if (NewQty != OldQty)
                    EditQuantity(NewQty, Index);


                itemPnl.Height = 33;

                ((ItemPanelTag)itemPnl.Tag).IsOpened = false;
            }
        }

        private void DeleteItemFromScreen(short index)
        {
            flpOrderReview.Controls.RemoveAt(index);

            // if not last index edit index of other itemsPanel
            if (index < flpOrderReview.Controls.Count)
            {
                ModifyNextItemsPanelTagIndex(index);
            }

            lblTotalPrice.Text = OrderBuilder.TotalPrice.ToString();

        }

        private void EditItemQtyFromScreen(short index)
        { // Edit Quantity and Price on screen
            short NewQty = OrderBuilder.CurrentOrderItemsList[index].ItemCount;

            int NewPrice = OrderBuilder.CurrentOrderItemsList[index].Price;

            flpOrderReview.Controls[index].Controls[1].Text = NewQty.ToString();
            flpOrderReview.Controls[index].Controls[2].Text = NewPrice.ToString();

            lblTotalPrice.Text = OrderBuilder.TotalPrice.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            Button btnDelete = (Button)sender;


            // get the parent itempanel of this delet button to be known which item must deleted
            Panel PnlParent = btnDelete.Parent as Panel;

            short Index = short.Parse(((ItemPanelTag)PnlParent.Tag).Index.ToString());

            OrderBuilder.DeleteItemFromCurrentOrderList(Index);

            DeleteItemFromScreen(Index);
        }

        private void EditQuantity(short NewQty, short Index)
        {

            OrderBuilder.EditQuantityOfThisItem(NewQty, Index);

            EditItemQtyFromScreen(Index);

        }


        private void OrderShow_Load(object sender, EventArgs e)
        {
            foreach (OrderItem orderItem in OrderBuilder.CurrentOrderItemsList)
            { 
                Panel itemPanel = MakeAnItemPanel();

                ItemPanelTag itemPanelTag = new ItemPanelTag(false, orderItem.IndexInCurrentOrderList);

                itemPanel.Tag = itemPanelTag;

                GenerateThisItemPanelControls(itemPanel, orderItem);

                // Add each item (panel) in the flow layout panels
                flpOrderReview.Controls.Add(itemPanel);
            }

            lblTotalPrice.Text = OrderBuilder.TotalPrice.ToString();
        }


        private void btnOrder_Click(object sender, EventArgs e)
        {
            // Store OrderBuilder.CurrentOrderItemsList in OrderManager.CurrentOrder from there it must be stored to database (but this doesn't happen)
            OrderManager.StoreCurrentOrder();

            // Store OrderManager.CurrentOrder
            OrderManager.StoreCurrentOrderToOrdersList();
            OrderBuilder.ResetCurrentOrderList();
            OrderBuilder.ResetItem();


            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OrderBuilder.ResetCurrentOrderList();
            OrderBuilder.ResetItem();
            

            this.Close();
        }

        private void frmOrderShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            OrderBuilder.ResetCurrentOrderList();
            OrderBuilder.ResetItem();
        }
    }
}
