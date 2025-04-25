using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wave_Priject
{
    class MenuSection
    {
        private byte SectioID { get; }

        public string SectionName { get; set; }

        public List<MenuItem> Items { get; set; }


        public MenuSection(byte ID, string Name, List<MenuItem> Items)
        {
            this.SectioID = ID;
            this.SectionName = Name;
            this.Items = Items;
        }

    }
}
