using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wave_Priject
{
    class Menu
    {
        private byte MenuID { get; }

        public string MenuName { get; set; }

        public List<MenuSection> Sections { get; set; }



        public Menu(byte ID, string Name, List<MenuSection> Sections)
        {
            this.MenuID = ID;
            this.MenuName = Name;
            this.Sections = Sections;
        }


    }
}
