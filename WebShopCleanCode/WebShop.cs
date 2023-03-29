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
        List<Product> products = new List<Product>();
        List<Customer> customers = new List<Customer>();

        private Menu menu = new Menu();
        
        string info = "What would you like to do?";

        string username = null;
        string password = null;
        Customer currentCustomer;

        public WebShop()
        {
            products = database.GetProducts();
            customers = database.GetCustomers();
        }

        public void Run()
        {
            Console.WriteLine("Welcome to the WebShop!");
            while (running)
            {
                Console.WriteLine(info);

                if (menu.currentMenu.Equals("purchase menu"))
                {
                    for (int i = 0; i < menu.amountOfOptions; i++)
                    {
                        Console.WriteLine(i + 1 + ": " + products[i].Name + ", " + products[i].Price + "kr");
                    }

                    Console.WriteLine("Your funds: " + currentCustomer.Funds);
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
                                    menu.WaresMenu();
                                    info = "What would you like to do?";
                                    break;
                                case 2:
                                    menu.CustomerMenu();
                                    info = "What would you like to do?";
                                    break;
                                case 3:
                                    LogInMenu();
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
                                    AddFund();
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
                                menu.WaresMenu();
                                info = "What would you like to do?";
                            }
                        }
                        else if (menu.currentMenu.Equals("wares menu"))
                        {
                            switch (menu.currentChoice)
                            {
                                case 1:
                                    SeeAllWares();
                                    break;
                                case 2:
                                    PurchaseWareMenu();
                                    break;
                                case 3:
                                    menu.SortWaresMenu();
                                    info = "How would you like to sort them?";
                                    break;
                                case 4:
                                    // TODO duplicated code but there is one different variable
                                    LogInMenu2();

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
                                    InputUserinfo(username, "username");
                                    break;
                                case 2:
                                    InputUserinfo(password, "password");
                                    break;
                                case 3:
                                    LogIn();
                                    break;
                                case 4:
                                    Register();
                                    break;
                                default:
                                    PrintDefaultMessage();
                                    break;
                            }
                        }
                        else if (menu.currentMenu.Equals("purchase menu"))
                        {
                            PurchaseWare();
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
                            menu.WaresMenu();
                            info = "What would you like to do?";
                        }
                        else
                        {
                            Console.WriteLine(info);
                            menu.NavigateToMainMenu();
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

        // purchase menu
        private void PurchaseWare()
        {
            int index = menu.currentChoice - 1;
            Product product = products[index];
            if (product.InStock())
            {
                if (currentCustomer.CanAfford(product.Price))
                {
                    currentCustomer.Funds -= product.Price;
                    product.NrInStock--;
                    currentCustomer.Orders.Add(new Order(product.Name, product.Price, DateTime.Now));
                    Console.WriteLine();
                    Console.WriteLine("Successfully bought " + product.Name);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("You cannot afford.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Not in stock.");
                Console.WriteLine();
            }
        }

        // login menu
        private void LogIn()
        {
            if (username == null || password == null)
            {
                Console.WriteLine();
                Console.WriteLine("Incomplete data.");
                Console.WriteLine();
            }
            else
            {
                bool found = false;
                foreach (Customer customer in customers)
                {
                    if (username.Equals(customer.Username) && customer.CheckPassword(password))
                    {
                        Console.WriteLine();
                        Console.WriteLine(customer.Username + " logged in.");
                        Console.WriteLine();
                        currentCustomer = customer;
                        found = true;
                        Console.WriteLine(info);
                        menu.NavigateToMainMenu();
                        break;
                    }
                }

                if (found == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid credentials.");
                    Console.WriteLine();
                }
            }
        }
        private void Register()
        {
            Console.WriteLine("Please write your username.");
            string newUsername = Console.ReadLine();
            foreach (Customer customer in customers)
            {
                if (customer.Username.Equals(username))
                {
                    Console.WriteLine();
                    Console.WriteLine("Username already exists.");
                    Console.WriteLine();
                    break;
                }
            }

            // Would have liked to be able to quit at any time in here.
            bool next = false;
            string newPassword = AskCustomerInfo("password", ref next);
            string firstName = AskCustomerInfo("first name", ref next);
            string lastName = AskCustomerInfo("last name", ref next);
            string email = AskCustomerInfo("email", ref next);

            // TODO age is integer, need another function?
            int age = AskCustomerAge(ref next);

            string address = AskCustomerInfo("address", ref next);
            // TODO slight different;
            string phoneNumber = AskCustomerPhoneNumber(ref next);

            Customer newCustomer = new Customer(newUsername, newPassword, firstName, lastName,
                email, age, address, phoneNumber);
            customers.Add(newCustomer);
            currentCustomer = newCustomer;
            Console.WriteLine();
            Console.WriteLine(
                newCustomer.Username + " successfully added and is now logged in.");
            Console.WriteLine();
            Console.WriteLine(info);
            menu.NavigateToMainMenu();
        }
        private string AskCustomerPhoneNumber(ref bool next)
        {
            string choice;
            string phoneNumber = null;
            while (true)
            {
                Console.WriteLine("Do you want a phone number? y/n");
                choice = Console.ReadLine();
                if (choice.Equals("y"))
                {
                    while (true)
                    {
                        Console.WriteLine("Please write your phone number.");
                        phoneNumber = Console.ReadLine();
                        if (phoneNumber.Equals(""))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please actually write something.");
                            Console.WriteLine();
                        }
                        else
                        {
                            next = true;
                            break;
                        }
                    }
                }

                if (choice.Equals("n") || next)
                {
                    break;
                }

                Console.WriteLine();
                Console.WriteLine("y or n, please.");
                Console.WriteLine();
            }
            return phoneNumber;
        }
        private int AskCustomerAge(ref bool next)
        {
            string choice;
            int age = -1;
            while (true)
            {
                Console.WriteLine("Do you want an age? y/n");
                choice = Console.ReadLine();
                if (choice.Equals("y"))
                {
                    while (true)
                    {
                        Console.WriteLine("Please write your age.");
                        string ageString = Console.ReadLine();
                        try
                        {
                            age = int.Parse(ageString);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please write a number.");
                            Console.WriteLine();
                            continue;
                        }

                        next = true;
                        break;
                    }
                }

                if (choice.Equals("n") || next)
                {
                    next = false;
                    break;
                }

                Console.WriteLine();
                Console.WriteLine("y or n, please.");
                Console.WriteLine();
            }

            return age;
        }
        private string AskCustomerInfo(string infoMessage, ref bool next)
        {
            string choice;
            string infoItem = null;
            while (true)
            {
                Console.WriteLine($"Do you want a {infoMessage}? y/n");
                choice = Console.ReadLine();
                if (choice.Equals("y"))
                {
                    while (true)
                    {
                        Console.WriteLine($"Please write your {infoMessage}.");
                        infoItem = Console.ReadLine();
                        if (infoItem.Equals(""))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please actually write something.");
                            Console.WriteLine();
                        }
                        else
                        {
                            next = true;
                            break;
                        }
                    }
                }

                if (choice.Equals("n") || next)
                {
                    next = false;
                    break;
                }

                Console.WriteLine();
                Console.WriteLine("y or n, please.");
                Console.WriteLine();
            }

            return infoItem;
        }
        private void InputUserinfo(string input, string infoName)
        {
            Console.WriteLine("A keyboard appears.");
            Console.WriteLine($"Please input your {infoName}.");
            input = Console.ReadLine();
            Console.WriteLine();
        }

        // customer menu
        private void AddFund()
        {
            Console.WriteLine("How many funds would you like to add?");
            string amountString = Console.ReadLine();
            try
            {
                int amount = int.Parse(amountString);
                if (amount < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Don't add negative amounts.");
                    Console.WriteLine();
                }
                else
                {
                    currentCustomer.Funds += amount;
                    Console.WriteLine();
                    Console.WriteLine(amount + " added to your profile.");
                    Console.WriteLine();
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine();
                Console.WriteLine("Please write a number next time.");
                Console.WriteLine();
            }
        }
        

        // sort menu
        private static void WareSortedNotification()
        {
            Console.WriteLine();
            Console.WriteLine("Wares sorted.");
            Console.WriteLine();
        }
        

        // wares menu
        private void PurchaseWareMenu()
        {
            if (currentCustomer != null)
            {
                menu.currentMenu = "purchase menu";
                info = "What would you like to purchase?";
                menu.currentChoice = 1;
                menu.amountOfOptions = products.Count;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You must be logged in to purchase wares.");
                Console.WriteLine();
                menu.currentChoice = 1;
            }
        }
        private void SeeAllWares()
        {
            Console.WriteLine();
            foreach (Product product in products)
            {
                product.PrintInfo();
            }

            Console.WriteLine();
        }
        private void LogInMenu2()
        {
            if (currentCustomer == null)
            {
                menu.option1 = "Set Username";
                menu.option2 = "Set Password";
                menu.option3 = "Login";
                menu.option4 = "Register";
                menu.amountOfOptions = 4;
                info = "Please submit username and password.";
                menu.currentChoice = 1;
                menu.currentMenu = "login menu";
            }
            else
            {
                menu.option4 = "Login";
                Console.WriteLine();
                Console.WriteLine(currentCustomer.Username + " logged out.");
                Console.WriteLine();
                currentCustomer = null;
                menu.currentChoice = 1;
            }
        }
        
        
        // main menu
        private void LogInMenu()
        {
            if (currentCustomer == null)
            {
                menu.option1 = "Set Username";
                menu.option2 = "Set Password";
                menu.option3 = "Login";
                menu.option4 = "Register";
                menu.amountOfOptions = 4;
                menu.currentChoice = 1;
                info = "Please submit username and password.";
                username = null;
                password = null;
                menu.currentMenu = "login menu";
            }
            else
            {
                menu.option3 = "Login";
                Console.WriteLine();
                Console.WriteLine(currentCustomer.Username + " logged out.");
                Console.WriteLine();
                menu.currentChoice = 1;
                currentCustomer = null;
            }
        }
        
        
        // all the menus
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
        
        private void bubbleSort(string variable, bool ascending)
        {
            if (variable.Equals("name"))
            {
                int length = products.Count;
                for (int i = 0; i < length - 1; i++)
                {
                    bool sorted = true;
                    int length2 = length - i;
                    for (int j = 0; j < length2 - 1; j++)
                    {
                        if (ascending)
                        {
                            if (products[j].Name.CompareTo(products[j + 1].Name) < 0)
                            {
                                Product temp = products[j];
                                products[j] = products[j + 1];
                                products[j + 1] = temp;
                                sorted = false;
                            }
                        }
                        else
                        {
                            if (products[j].Name.CompareTo(products[j + 1].Name) > 0)
                            {
                                Product temp = products[j];
                                products[j] = products[j + 1];
                                products[j + 1] = temp;
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
                int length = products.Count;
                for (int i = 0; i < length - 1; i++)
                {
                    bool sorted = true;
                    int length2 = length - i;
                    for (int j = 0; j < length2 - 1; j++)
                    {
                        if (ascending)
                        {
                            if (products[j].Price > products[j + 1].Price)
                            {
                                Product temp = products[j];
                                products[j] = products[j + 1];
                                products[j + 1] = temp;
                                sorted = false;
                            }
                        }
                        else
                        {
                            if (products[j].Price < products[j + 1].Price)
                            {
                                Product temp = products[j];
                                products[j] = products[j + 1];
                                products[j + 1] = temp;
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