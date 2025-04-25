using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wave_Priject
{
    class DataStore
    {
        private DataStore()
        {

        }

        //                        MenusItems Lists                          //
        static List<MenuItem> ltPizza = new List<MenuItem>();
        static List<MenuItem> ltBurger = new List<MenuItem>();
        static List<MenuItem> ltChicken = new List<MenuItem>();
        static List<MenuItem> ltMeat = new List<MenuItem>();
        //                      -----------------------                       //

        static List<MenuItem> ltChocoDessert = new List<MenuItem>();
        static List<MenuItem> ltIceCream = new List<MenuItem>();
        static List<MenuItem> ltApplPie = new List<MenuItem>();
        static List<MenuItem> ltDonut = new List<MenuItem>();
        //                      -----------------------  
        //
        static List<MenuItem> ltCoffees = new List<MenuItem>();
        static List<MenuItem> ltTea= new List<MenuItem>();
        static List<MenuItem> ltOtherHots = new List<MenuItem>();

        //                      -----------------------                       //
        static List<MenuItem> ltJuices = new List<MenuItem>();
        static List<MenuItem> ltCola = new List<MenuItem>();
        static List<MenuItem> ltOtherColds = new List<MenuItem>();



        //-------------------------------------------------------------------------



        //                           MenuSections Lists                          //
        static List<MenuSection> ltMainSections = new List<MenuSection>();
        static List<MenuSection> ltDessertSections = new List<MenuSection>();
        static List<MenuSection> ltHotSections = new List<MenuSection>();
        static List<MenuSection> ltColdSections = new List<MenuSection>();
        //                      -----------------------                       //

        //-------------------------------------------------------------------------


        //                           Menus object                                //
        public static Menu MainMenu = new Menu(1, "Main Menu", ltMainSections);
        public static Menu DessertMenu = new Menu(2, "Dessert Menu", ltDessertSections);
        public static Menu HotMenu = new Menu(3, "Hot Menu", ltHotSections);
        public static Menu ColdMenu = new Menu(4, "Cold Menu", ltColdSections);
        //-------------------------------------------------------------------------


      //                        MenusSections objects                          //

        private static MenuSection secPizza = new MenuSection(1, "Pizza", ltPizza);
        private static MenuSection secBurger = new MenuSection(2, "Burger", ltBurger);
        private static MenuSection secChicken = new MenuSection(3, "Chicken", ltChicken);
        private static MenuSection secMeat= new MenuSection(4, "Meat", ltMeat);
        //                      -----------------------                       //

        private static MenuSection secChocoDessert = new MenuSection(1, "Pizza", ltChocoDessert);
        private static MenuSection secIceCream = new MenuSection(2, "Burger", ltIceCream);
        private static MenuSection secApplPie = new MenuSection(3, "Chicken", ltApplPie);
        private static MenuSection secDonut  = new MenuSection(4, "Meat", ltDonut); 
        //                      -----------------------                       //

        private static MenuSection secJuices = new MenuSection(1, "Juices", ltJuices);
        private static MenuSection secCola = new MenuSection(2, "Cola", ltCola);
        private static MenuSection secOtherCold = new MenuSection(3, "Other Cold", ltOtherColds);
        //                      -----------------------                       //

        private static MenuSection secCoffee = new MenuSection(1, "Coffee", ltCoffees);
        private static MenuSection secTea = new MenuSection(2, "Tea", ltTea);
        private static MenuSection secOtherHot = new MenuSection(3, "Other Hot", ltOtherHots);


        //-------------------------------------------------------------------------
        //                        MenusItems Objects                          //


        private static MenuItem Margherita = new MenuItem(1, "Margherita", 80, 111);
        private static MenuItem Pepperoni = new MenuItem(2, "Pepperoni", 75, 112);
        private static MenuItem BBQChickenPizza = new MenuItem(3, "BBQ Chicken Pizza", 85, 113);
                
        private static MenuItem CheeseBurger = new MenuItem(1, "Cheese Burger", 65, 121);
        private static MenuItem MushroomBurger = new MenuItem(2, "Mushroom Burger", 60,122);
        private static MenuItem ChickenBurger = new MenuItem(3, "Chicken Burger", 70, 123);
                
        private static MenuItem GrilledChicken = new MenuItem(1, "Grilled Chicken", 100, 131);
        private static MenuItem ChickenTikka = new MenuItem(2, "Chicken Tikka", 95, 132);
                
        private static MenuItem Steak = new MenuItem(1, "Steak", 110, 141);
        private static MenuItem LambChops = new MenuItem(2, "Lamb Chops", 115, 142);
        private static MenuItem BeefKoffta = new MenuItem(3, "Beef Koffta", 100, 143);
        private static MenuItem BuffloWings = new MenuItem(4, "Bufflo Wings", 105, 144);

        //                      -----------------------                       //

        private static MenuItem ChocoLavaCake = new MenuItem(1, "Chocolate Lava Cake", 50, 211);
        private static MenuItem BlackForestCake = new MenuItem(2, "Black Forest Cake", 55, 212);

        private static MenuItem VanilaIC = new MenuItem(1, "Vanila Ice Cream", 40, 221);
        private static MenuItem ChocoIC = new MenuItem(2, "Chocolate Ice Cream", 40, 222);
        private static MenuItem StrawberryIC = new MenuItem(3, "Stawberry Ice Cream", 40, 223);

        private static MenuItem ClassicAP = new MenuItem(1, "Classic Apple Pie", 45, 231);
        private static MenuItem DutschAP = new MenuItem(2, "Dutsch Apple Pie", 45, 232);
        private static MenuItem CaramelAP = new MenuItem(3, "Caramel Apple Pie", 45, 233);

        private static MenuItem GlazeDonut = new MenuItem(1, "GlazeDonut", 35, 241);
        private static MenuItem CinnamonDonut = new MenuItem(2, "CinnamonDonut", 35, 242);

        //                      -----------------------                       //
        private static MenuItem Mango = new MenuItem(1, "Mango", 70, 311);
        private static MenuItem Strawberry = new MenuItem(2, "Strawberry", 75, 312);
        private static MenuItem Orange = new MenuItem(3, "Orange", 65, 313);
        private static MenuItem PineApple = new MenuItem(4, "PineApple", 70, 314);
        private static MenuItem Lemon = new MenuItem(5, "Lemon ", 60, 315);

        private static MenuItem SevenUp = new MenuItem(1, "Seven Up", 50, 321);
        private static MenuItem CokaCola = new MenuItem(2, "Coka Cola ", 50, 322);
        private static MenuItem Schweppes = new MenuItem(3, "Schweppes", 55, 323);

        private static MenuItem IcedCoffee = new MenuItem(1, "Iced Coffee", 40, 331);
        private static MenuItem IcedTea = new MenuItem(2, "Iced Tea", 40, 332);

        //                      -----------------------                       //
        private static MenuItem TurkishCoffee = new MenuItem(1, "Turkish Coffee", 45, 411);
        private static MenuItem FrenshCoffee= new MenuItem(2, "Frensh Coffee", 55, 412);
        private static MenuItem Essepresso = new MenuItem(3, "Essepresso", 60, 413);
        private static MenuItem Cappuccino = new MenuItem(4, "Cappuccino", 60, 414);
        private static MenuItem Latte = new MenuItem(5, "Latte", 65, 415);
        private static MenuItem Mocha = new MenuItem(6, "Mocha", 70, 416);

        private static MenuItem PlainTea = new MenuItem(1, "Plain Tea", 35, 421);
        private static MenuItem TeawMilk = new MenuItem(2, "Tea With Milk", 45, 422);
        private static MenuItem GreenTea = new MenuItem(3, "Green Tea", 40, 423);

        private static MenuItem HotChocolate = new MenuItem(1, "Hot Chocolate", 65, 431);


        //-------------------------------------------------------------------------






        //   Fill Sections With Items                                          //

        private static void AddPizzaItemsToList()
        {
            ltPizza.Add(Margherita);
            ltPizza.Add(Pepperoni);
            ltPizza.Add(BBQChickenPizza);
        }
        private static void AddChickenItemsToList()
        {
            ltBurger.Add(CheeseBurger);
            ltBurger.Add(MushroomBurger);
            ltBurger.Add(ChickenBurger);
        }
        private static void AddBurgerItemsToList()
        {
            ltChicken.Add(GrilledChicken);
            ltChicken.Add(ChickenTikka);
        }
        private static void AddMeatItemsToList()
        {
            ltMeat.Add(Steak);
            ltMeat.Add(LambChops);
            ltMeat.Add(BeefKoffta);
            ltMeat.Add(BuffloWings);
        }
        private static void AddChocoDessertItemsToList()
        {
            ltChocoDessert.Add(ChocoLavaCake);
            ltChocoDessert.Add(BlackForestCake);
        }
        private static void AddApplePieItemsToList()
        {
            ltIceCream.Add(VanilaIC);
            ltIceCream.Add(ChocoIC);
            ltIceCream.Add(StrawberryIC);
        }
        private static void AddIceCreamItemsToList()
        {
            ltApplPie.Add(ClassicAP);
            ltApplPie.Add(DutschAP);
            ltApplPie.Add(CaramelAP);

        }
        private static void AddDonutItemsToList()
        {
            ltDonut.Add(GlazeDonut);
            ltDonut.Add(CinnamonDonut);
        }
        private static void AddCoffeeItemsToList()
        {
            ltCoffees.Add(TurkishCoffee);
            ltCoffees.Add(FrenshCoffee);
            ltCoffees.Add(Essepresso);
            ltCoffees.Add(Cappuccino);
            ltCoffees.Add(Latte);
            ltCoffees.Add(Mocha);
        }
        private static void AddTeaItemsToList()
        {
            ltTea.Add(PlainTea);
            ltTea.Add(TeawMilk);
            ltTea.Add(GreenTea);
        }
        private static void AddOtherHotDrinkiesItemsToList()
        {
            ltOtherHots.Add(HotChocolate);

        }
        private static void AddJuicesItemsToList()
        {
            ltJuices.Add(Mango);
            ltJuices.Add(Strawberry);
            ltJuices.Add(Orange);
            ltJuices.Add(PineApple);
            ltJuices.Add(Lemon);
        }
        private static void AddColaItemsToList()
        {
            ltCola.Add(SevenUp);
            ltCola.Add(CokaCola);
            ltCola.Add(Schweppes);
        }
        private static void AddOtherColdDrinkiesItemsToList()
        {
            ltOtherColds.Add(IcedCoffee);
            ltOtherColds.Add(IcedTea);
            

        }
 
        
        
        // Add all menus Items to their list of the Sections to be added to the Section object
        public static void AddItemToSectionsLists ()
        {
            AddPizzaItemsToList();
            AddChickenItemsToList();
            AddBurgerItemsToList();
            AddMeatItemsToList();
            AddChocoDessertItemsToList();
            AddApplePieItemsToList();
            AddIceCreamItemsToList();
            AddDonutItemsToList();
            AddCoffeeItemsToList();
            AddTeaItemsToList();
            AddOtherHotDrinkiesItemsToList();
            AddJuicesItemsToList();
            AddColaItemsToList();
            AddOtherColdDrinkiesItemsToList();
        }


        //-------------------------------------------------------------------------

        // Fill Menus With Sections                                           //

        private static void AddMainSectionsToList ()
        {
            ltMainSections.Add(secPizza);
            ltMainSections.Add(secBurger);
            ltMainSections.Add(secChicken);
            ltMainSections.Add(secMeat);

        }
        private static void AddDessertSectionsToList()
        {
            ltDessertSections.Add(secChocoDessert);
            ltDessertSections.Add(secIceCream);
            ltDessertSections.Add(secApplPie);
            ltDessertSections.Add(secDonut);
        }
        private static void AddColdSectionsToList()
        {
            ltColdSections.Add(secJuices);
            ltColdSections.Add(secCola);
            ltColdSections.Add(secOtherCold);
        }
        private static void AddHotSectionsToList()
        {
            ltHotSections.Add(secCoffee);
            ltHotSections.Add(secTea);
            ltHotSections.Add(secOtherHot);
        }


        // Add all menus Sections to their list of the menu to be added to the menu object
        public static void AddSectionsToMenusLists()
        {
            AddMainSectionsToList();
            AddDessertSectionsToList();
            AddColdSectionsToList();
            AddHotSectionsToList();
        }

        //-------------------------------------------------------------------------

       



        


    }
}
