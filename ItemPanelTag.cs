using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wave_Priject
{
    class ItemPanelTag
    {

        public bool IsOpened { get; set; }

        // Storing the radio button that include this item to be easy reach to index and IsExist
        public RadioButton ItemRB { get; set; }

        public short Index { get; set; }

        public ItemPanelTag(bool IsOpened,RadioButton rb) // used in order summary item panel
        {
            this.IsOpened = IsOpened;
            this.ItemRB = rb;
        }

        public ItemPanelTag(bool IsOpened, short Index) // used in order show item panels after press order
        {
            this.IsOpened = IsOpened;
            this.Index = Index;
            ItemRB = null;
        }


        public ItemPanelTag()
        {
           
        }


    }
}
