using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WebShopCleanCode
{
    public class WebShop
    {
        bool running = true;
        Database database = new Database();
        // List<Product> products = new List<Product>();
        
        ProductList productList = new ProductList();
        List<Customer> customers = new List<Customer>();

        private LoginMenu LoginMenu = new LoginMenu();
        private Menu menu = new Menu();
        
        // string info = "What would you like to do?";

        // string username = null;
        // string password = null;
        Customer currentCustomer;

        public WebShop()
        {
            // products = database.GetProducts();
            customers = database.GetCustomers();
        }

        public void Run()
        {
            Console.WriteLine("Welcome to the WebShop!");
            while (running)
            {
                Console.WriteLine(menu.Info);

                if (menu.currentMenu.Equals("purchase menu"))
                {
                    productList.GetProductList(currentCustomer);
                }
                else
                {
                    menu.MainMenu();
                }

                menu.MenuBar();
                CheckLogInStatus();

                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "left":
                    case "l":
                        if (menu.currentChoice > 1)
                        {
                            menu.currentChoice--;
                        }

                        break;
                    case "right":
                    case "r":
                        if (menu.currentChoice < menu.amountOfOptions)
                        {
                            menu.currentChoice++;
                        }

                        break;
                    case "ok":
                    case "k":
                    case "o":
                        if (menu.currentMenu.Equals("main menu"))
                        {
                            switch (menu.currentChoice)
                            {
                                case 1:
                                    menu.WaresMenu("What would you like to do?", currentCustomer);
                                    break;
                                case 2:
                                    menu.CustomerMenu("What would you like to do?", currentCustomer);
                                    break;
                                case 3:
                                    menu.LogInMenu("Please submit username and password.", currentCustomer);
                                    break;
                                default:
                                    PrintDefaultMessage();
                                    break;
                            }
                        }
                        else if (menu.currentMenu.Equals("customer menu"))
                        {
                            switch (menu.currentChoice)
                            {
                                case 1:
                                    currentCustomer.PrintOrders();
                                    break;
                                case 2:
                                    currentCustomer.PrintInfo();
                                    break;
                                case 3:
                                    menu.AddFund(currentCustomer);
                                    break;
                                default:
                                    PrintDefaultMessage();
                                    break;
                            }
                        }
                        else if (menu.currentMenu.Equals("sort menu"))
                        {
                            bool back = true;
                            switch (menu.currentChoice)
                            {
                                case 1:
                                    bubbleSort("name", false);
                                    WareSortedNotification();
                                    break;
                                case 2:
                                    bubbleSort("name", true);
                                    WareSortedNotification();
                                    break;
                                case 3:
                                    bubbleSort("price", false);
                                    WareSortedNotification();
                                    break;
                                case 4:
                                    bubbleSort("price", true);
                                    WareSortedNotification();
                                    break;
                                default:
                                    back = false;
                                    PrintDefaultMessage();
                                    break;
                            }

                            if (back)
                            {
                                menu.WaresMenu("What would you like to do?", currentCustomer);
                            }
                        }
                        else if (menu.currentMenu.Equals("wares menu"))
                        {
                            switch (menu.currentChoice)
                            {
                                case 1:
                                    productList.SeeAllWares();
                                    break;
                                case 2:
                                    menu.PurchaseWareMenu(currentCustomer, productList.products, "What would you like to purchase?");
                                    break;
                                case 3:
                                    menu.SortWaresMenu("How would you like to sort them?");
                                    break;
                                case 4:
                                    // TODO duplicated code but there is one different variable
                                    menu.NavigateFromWaresMenuToLoginMenu("Please submit username and password.", currentCustomer);
                                    break;
                                case 5:
                                    break;
                                default:
                                    PrintDefaultMessage();
                                    break;
                            }
                        }
                        else if (menu.currentMenu.Equals("login menu"))
                        {
                            switch (menu.currentChoice)
                            {
                                case 1:
                                    LoginMenu.username = LoginMenu.InputUserInfo("username");
                                    break;
                                case 2:
                                    LoginMenu.password = LoginMenu.InputUserInfo("password");
                                    break;
                                case 3:
                                    LoginMenu.LogIn(currentCustomer, customers);
                                    break;
                                case 4:
                                    LoginMenu.Register(currentCustomer, customers);
                                    break;
                                default:
                                    PrintDefaultMessage();
                                    break;
                            }
                        }
                        else if (menu.currentMenu.Equals("purchase menu"))
                        {
                            productList.PurchaseWare(currentCustomer);
                        }

                        break;
                    case "back":
                    case "b":
                        if (menu.currentMenu.Equals("main menu"))
                        {
                            Console.WriteLine();
                            Console.WriteLine("You're already on the main menu.");
                            Console.WriteLine();
                        }
                        else if (menu.currentMenu.Equals("purchase menu"))
                        {
                            menu.WaresMenu("What would you like to do?", currentCustomer);
                        }
                        else
                        {
                            Console.WriteLine(menu.Info);
                            menu.NavigateToMainMenu(currentCustomer);
                        }

                        break;
                    case "quit":
                    case "q":
                        Console.WriteLine("The console powers down. You are free to leave.");
                        return;
                    default:
                        Console.WriteLine("That is not an applicable option.");
                        break;
                }
            }
        }
        

        private static void PrintDefaultMessage()
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
        private static void WareSortedNotification()
        {
            Console.WriteLine();
            Console.WriteLine("Wares sorted.");
            Console.WriteLine();
        }
        private void bubbleSort(string variable, bool ascending)
        {
            if (variable.Equals("name"))
            {
                int length = productList.products.Count;
                for (int i = 0; i < length - 1; i++)
                {
                    bool sorted = true;
                    int length2 = length - i;
                    for (int j = 0; j < length2 - 1; j++)
                    {
                        if (ascending)
                        {
                            if (productList.products[j].Name.CompareTo(productList.products[j + 1].Name) < 0)
                            {
                                Product temp = productList.products[j];
                                productList.products[j] = productList.products[j + 1];
                                productList.products[j + 1] = temp;
                                sorted = false;
                            }
                        }
                        else
                        {
                            if (productList.products[j].Name.CompareTo(productList.products[j + 1].Name) > 0)
                            {
                                Product temp = productList.products[j];
                                productList.products[j] = productList.products[j + 1];
                                productList.products[j + 1] = temp;
                                sorted = false;
                            }
                        }
                    }

                    if (sorted == true)
                    {
                        break;
                    }
                }
            }
            else if (variable.Equals("price"))
            {
                int length = productList.products.Count;
                for (int i = 0; i < length - 1; i++)
                {
                    bool sorted = true;
                    int length2 = length - i;
                    for (int j = 0; j < length2 - 1; j++)
                    {
                        if (ascending)
                        {
                            if (productList.products[j].Price > productList.products[j + 1].Price)
                            {
                                Product temp = productList.products[j];
                                productList.products[j] = productList.products[j + 1];
                                productList.products[j + 1] = temp;
                                sorted = false;
                            }
                        }
                        else
                        {
                            if (productList.products[j].Price < productList.products[j + 1].Price)
                            {
                                Product temp = productList.products[j];
                                productList.products[j] = productList.products[j + 1];
                                productList.products[j + 1] = temp;
                                sorted = false;
                            }
                        }
                    }

                    if (sorted == true)
                    {
                        break;
                    }
                }
            }
        }
    }
}