using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wave_Priject
{
    class ItemRadioButtonTag
    {
        public string ItemCode { get; set; }

        public bool IsExist { get; set; }

        public short Index { get; set; } 

        public Panel ItemPanel { get; set; }




        public ItemRadioButtonTag(string ItemCode)
        {
            this.ItemCode = ItemCode;
            this.IsExist = false;
            this.ItemPanel = null ;
        }
        public ItemRadioButtonTag(string ItemCode, bool IsExist , Panel pnl, short Index)
        {
            this.ItemCode = ItemCode;
            this.IsExist = IsExist;
            this.ItemPanel = pnl;
            this.Index = Index;
        }

        // store data of radio button (panel)(IsExist)index in Current order List (Index)
        // after adding the new item in list then in panel then this data stored in item radio button tag object
        // used in ShowOrderItem that called when fire the add to oreder button event
        public static void StoreRadioButtonData(Panel itemPanel , RadioButton rb, short ItemPanelIndex)
        {
            ((ItemRadioButtonTag)rb.Tag).ItemPanel = itemPanel;
            ((ItemRadioButtonTag)rb.Tag).IsExist = true;
            ((ItemRadioButtonTag)rb.Tag).Index = ItemPanelIndex;
        }

    }
}
