using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wave_Priject
{
    public struct MenusMap 
    {
        public static Byte MenusNum;
        public struct Main
        {
            public static Byte MainMenuSections;
            public static Byte PizzaSectionItems;
            public static Byte BurgerSectionItems;
            public static Byte ChickenSectionItems;
            public static Byte MeatsSectionItems;
        }

        public struct Dessert
        {
            public static Byte DessertMenuSections;
            public static Byte ChocolateSectionItems;
            public static Byte IceCreamSectionItems;
            public static Byte ApplePieSectionItems;
            public static Byte DonutSectionItems;
        }
        public struct Hot
        {
            public static Byte HotMenuSections;
            public static Byte CoffeesSectionItems;
            public static Byte TeaSectionItems;
            public static Byte OtherHotsSectionItems;
        }
        public struct Cold
        {
            public static Byte ColdMenuSection;
            public static Byte JuicesSectionItems;
            public static Byte ColaSectionItems;
            public static Byte OtherColdsSectionItems;
        }
        
    }

    class MenusManager
    {
        private MenusManager ()
        {

        }

        MenusMap MenusMap;


        // store the menu section numbers and menu item numbers and section items numbers
        public static void FillMenusMap ()
        {
            MenusMap.MenusNum = (byte) RestaurantMenus.Count();

            MenusMap.Main.MainMenuSections = (byte)RestaurantMenus.ElementAt(0).Sections.Count();
            MenusMap.Main.PizzaSectionItems = (byte)RestaurantMenus.ElementAt(0).Sections.ElementAt(3).Items.Count();
            MenusMap.Main.BurgerSectionItems = (byte)RestaurantMenus.ElementAt(0).Sections.ElementAt(1).Items.Count();
            MenusMap.Main.ChickenSectionItems = (byte)RestaurantMenus.ElementAt(0).Sections.ElementAt(2).Items.Count();
            MenusMap.Main.MeatsSectionItems = (byte)RestaurantMenus.ElementAt(0).Sections.ElementAt(3).Items.Count();


            MenusMap.Dessert.DessertMenuSections = (byte) RestaurantMenus.ElementAt(1).Sections.Count();
            MenusMap.Dessert.ChocolateSectionItems = (byte) RestaurantMenus.ElementAt(1).Sections.ElementAt(0).Items.Count();
            MenusMap.Dessert.IceCreamSectionItems = (byte) RestaurantMenus.ElementAt(1).Sections.ElementAt(1).Items.Count();
            MenusMap.Dessert.ApplePieSectionItems = (byte) RestaurantMenus.ElementAt(1).Sections.ElementAt(2).Items.Count();
            MenusMap.Dessert.DonutSectionItems = (byte) RestaurantMenus.ElementAt(1).Sections.ElementAt(3).Items.Count();

            MenusMap.Hot.HotMenuSections = (byte)RestaurantMenus.ElementAt(2).Sections.Count();
            MenusMap.Hot.CoffeesSectionItems = (byte)RestaurantMenus.ElementAt(2).Sections.ElementAt(0).Items.Count();
            MenusMap.Hot.TeaSectionItems = (byte)RestaurantMenus.ElementAt(2).Sections.ElementAt(1).Items.Count();
            MenusMap.Hot.OtherHotsSectionItems = (byte)RestaurantMenus.ElementAt(2).Sections.ElementAt(2).Items.Count();

            MenusMap.Cold.ColdMenuSection = (byte)RestaurantMenus.ElementAt(3).Sections.Count();
            MenusMap.Cold.JuicesSectionItems = (byte)RestaurantMenus.ElementAt(3).Sections.ElementAt(0).Items.Count();
            MenusMap.Cold.ColaSectionItems = (byte)RestaurantMenus.ElementAt(3).Sections.ElementAt(1).Items.Count();
            MenusMap.Cold.OtherColdsSectionItems = (byte)RestaurantMenus.ElementAt(3).Sections.ElementAt(2).Items.Count();

        }
        

        // This List includes the Four Menus In the Restaurant (Main, Dessert, Hot, Cold) to show them in Managment list
        public static List<Menu> RestaurantMenus = new List<Menu>();


        // To fill the RestaurantMenus list with existing 4 menus
        public static void FillMenusList()
        {
            RestaurantMenus.Add(DataStore.MainMenu);
            RestaurantMenus.Add(DataStore.DessertMenu);
            RestaurantMenus.Add(DataStore.ColdMenu);
            RestaurantMenus.Add(DataStore.HotMenu);
        }
        
        
        
        // To check that item code is not out of the range
        public static bool IsItemCodeOutOfTheMenusRange(byte MenuIndex, byte sectionIndex, byte itemIndex)
        {

            switch (MenuIndex)
            {
                case 0:
                    switch (sectionIndex)
                    {
                        case 0:
                            if (itemIndex >= (byte)RestaurantMenus.ElementAt(0).Sections.ElementAt(0).Items.Count())
                                return true;

                            return false;

                        case 1:
                            if (itemIndex >= (byte)RestaurantMenus.ElementAt(0).Sections.ElementAt(1).Items.Count())
                                return true;

                            return false;

                        case 2:
                            if (itemIndex >= (byte)RestaurantMenus.ElementAt(0).Sections.ElementAt(2).Items.Count())
                                return true;
                            return false;

                        case 3:
                            if (itemIndex >= (byte)RestaurantMenus.ElementAt(0).Sections.ElementAt(3).Items.Count())
                                return true;

                            return false;


                        default:
                            return true;
                    }

                case 1:
                    switch (sectionIndex)
                    {
                        case 0:
                            if (itemIndex >= (byte)RestaurantMenus.ElementAt(1).Sections.ElementAt(0).Items.Count())
                                return true;

                            return false;

                        case 1:
                            if (itemIndex >= (byte)RestaurantMenus.ElementAt(1).Sections.ElementAt(1).Items.Count())
                                return true;

                            return false;

                        case 2:
                            if (itemIndex >= (byte)RestaurantMenus.ElementAt(1).Sections.ElementAt(2).Items.Count())
                                return true;
                            return false;

                        case 3:
                            if (itemIndex >= (byte)RestaurantMenus.ElementAt(1).Sections.ElementAt(3).Items.Count())
                                return true;

                            return false;


                        default:
                            return true;
                    }

                case 2:
                    switch (sectionIndex)
                    {
                        case 0:
                            if (itemIndex >= (byte)RestaurantMenus.ElementAt(2).Sections.ElementAt(0).Items.Count())
                                return true;

                            return false;

                        case 1:
                            if (itemIndex >= (byte)RestaurantMenus.ElementAt(2).Sections.ElementAt(1).Items.Count())
                                return true;

                            return false;

                        case 2:
                            if (itemIndex >= (byte)RestaurantMenus.ElementAt(2).Sections.ElementAt(2).Items.Count())
                                return true;

                            return false;

                        default:
                            return true;
                    }

                case 3:

                    switch(sectionIndex)
                    {
                        case 0:
                            if (itemIndex >= (byte)RestaurantMenus.ElementAt(3).Sections.ElementAt(0).Items.Count())
                                return true;

                            return false;

                        case 1:
                            if (itemIndex >= (byte)RestaurantMenus.ElementAt(3).Sections.ElementAt(1).Items.Count())
                                return true;

                            return false;

                        case 2:
                            if (itemIndex >= (byte)RestaurantMenus.ElementAt(3).Sections.ElementAt(2).Items.Count())
                                return true;
                            return false;

                        default:
                            return true;
                    }

                default:
                    return true;

            }
        }

    }
}
