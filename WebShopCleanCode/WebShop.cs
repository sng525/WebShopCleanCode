using System.ComponentModel.Design;
using WebShopCleanCode.Command;
using WebShopCleanCode.LeftRightOkBackCommand;
using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;

namespace WebShopCleanCode
{
    public class WebShop
    {
        bool running = true;
        
        Database database = new Database();
        ProductList productList = new ProductList();
        
        List<Customer> customers;
        Customer currentCustomer = null;
        
        public int currentChoice = 1;
        public int amountOfOptions = 4;
        private MenuBase menu = new MainMenu();
        
        private Dictionary<(string currentMenu, int currentChoice), ICommand> menuCommandDictionary = new Dictionary<(string currentMenu, int currentChoice), ICommand>();
        private Dictionary<string, IDirectionCommand> directionCommandDict = new Dictionary<string, IDirectionCommand>();
        
        public WebShop()
        {
            customers = database.GetCustomers();
            menuCommandDictionary = InitializeMenuCommandDictionary();
            directionCommandDict = InitializeDirectionCommandDictionary();
        }
        
        public void Run()
        {
            Console.WriteLine("Welcome to the WebShop!");
            
            
            while (running)
            {
                // Console.WriteLine("What would you like to do?");

                if (menu.currentMenu.Equals("purchase menu"))
                {
                    productList.GetProductList(currentCustomer, amountOfOptions);
                }
                else
                {
                    menu.DisplayMenu(currentCustomer, ref amountOfOptions);
                }

                MenuBar();
                CheckLogInStatus();

                

                string choice = Console.ReadLine().ToLower();
                
                if (directionCommandDict.TryGetValue(choice.ToLowerInvariant(), out var command))
                {
                    command.Execute(ref currentChoice, ref amountOfOptions, menu.currentMenu);
                }
                else
                {
                    Console.WriteLine("That is not an applicable option.");
                }
                
            }
        }

        public void MenuBar()
        {
            for (int i = 0; i < amountOfOptions; i++)
            {
                Console.Write(i + 1 + "\t");
            }

            Console.WriteLine();
            for (int i = 1; i < currentChoice; i++)
            {
                Console.Write("\t");
            }

            Console.WriteLine("|");

            Console.WriteLine("Your buttons are Left, Right, OK, Back and Quit.");
        }
        
        public static void PrintDefaultMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Not an option.");
            Console.WriteLine();
        }
        
        private void CheckLogInStatus()
        {
            if (currentCustomer != null)
            {
                Console.WriteLine("Current user: " + currentCustomer.Username);
            }
            else
            {
                Console.WriteLine("Nobody logged in.");
            }
        }
        
        private Dictionary<string, IDirectionCommand> InitializeDirectionCommandDictionary()
        {
            directionCommandDict.Add("left", new LeftCommand());
            directionCommandDict.Add("l", new LeftCommand());
            
            directionCommandDict.Add("right", new RightCommand());
            directionCommandDict.Add("r", new RightCommand());
            
            directionCommandDict.Add("ok", new OkCommand(menuCommandDictionary));
            directionCommandDict.Add("k", new OkCommand(menuCommandDictionary));
            directionCommandDict.Add("o", new OkCommand(menuCommandDictionary));
            
            directionCommandDict.Add("back", new BackCommand(menu, currentCustomer));
            directionCommandDict.Add("b", new BackCommand(menu, currentCustomer));
            
            directionCommandDict.Add("quit", new QuitCommand());
            directionCommandDict.Add("q", new QuitCommand());
            return directionCommandDict;
        }
        
        private Dictionary<(string currentMenu, int currentChoice), ICommand> InitializeMenuCommandDictionary()
        {
            menuCommandDictionary.Add(("main menu", 1), new MainMenuCommand());
            menuCommandDictionary.Add(("main menu", 2), new MainMenuCommand());
            menuCommandDictionary.Add(("main menu", 3), new MainMenuCommand());
            
            menuCommandDictionary.Add(("customer menu", 1), new CustomerMenuCommand());
            menuCommandDictionary.Add(("customer menu", 2), new CustomerMenuCommand());
            menuCommandDictionary.Add(("customer menu", 3), new CustomerMenuCommand());
            
            menuCommandDictionary.Add(("sort menu", 1), new SortWaresMenuCommand(new SortWaresMenu(), productList.products));
            menuCommandDictionary.Add(("sort menu", 2), new SortWaresMenuCommand(new SortWaresMenu(), productList.products));
            menuCommandDictionary.Add(("sort menu", 3), new SortWaresMenuCommand(new SortWaresMenu(), productList.products));
            menuCommandDictionary.Add(("sort menu", 4), new SortWaresMenuCommand(new SortWaresMenu(), productList.products));
            
            menuCommandDictionary.Add(("wares menu", 1), new WaresMenuCommand(new WaresMenu(), productList.products));
            menuCommandDictionary.Add(("wares menu", 2), new WaresMenuCommand(new WaresMenu(), productList.products));
            menuCommandDictionary.Add(("wares menu", 3), new WaresMenuCommand(new WaresMenu(), productList.products));
            menuCommandDictionary.Add(("wares menu", 4), new WaresMenuCommand(new WaresMenu(), productList.products));
            
            menuCommandDictionary.Add(("login menu", 1), new LogInMenuCommand(new MainMenu(), customers));
            menuCommandDictionary.Add(("login menu", 2), new LogInMenuCommand(new MainMenu(), customers));
            menuCommandDictionary.Add(("login menu", 3), new LogInMenuCommand(new MainMenu(), customers));
            menuCommandDictionary.Add(("login menu", 4), new LogInMenuCommand(new MainMenu(), customers));
            
            menuCommandDictionary.Add(("purchase menu", 1), new PurchaseMenuCommand(new PurchaseMenu(), productList.products));
            return menuCommandDictionary;
        }
    }
}