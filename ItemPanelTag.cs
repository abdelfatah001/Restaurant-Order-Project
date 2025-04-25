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
        public short flpInedx { get; set; }

        public bool IsOpened { get; set; }

        public RadioButton rb { get; set; }

        public ItemPanelTag(short Index, bool IsOpened,RadioButton rb)
        {
            this.flpInedx = Index;
            this.IsOpened = IsOpened;
            this.rb = rb;
        }

        public ItemPanelTag()
        {
           
        }


    }
}
