

using WebShopCleanCode;
using WebShopCleanCode.Command;
using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;

public class LogInMenuCommand : ICommand
{
    MainMenu _menu;
    private string username { get; set; }
    private string password { get; set; }
    private List<Customer> _customers;
    
    public LogInMenuCommand(MainMenu menu, List<Customer> customers)
    {
        _menu = menu;
        _customers = customers;
    }

    public void Execute(Customer currentCustomer, ref int currentChoice, ref int amountOfOptions)
    {
        switch (currentChoice)
        {
            case 1:
                username =InputUserInfo("username");
                break;
            case 2:
                password = InputUserInfo("password");
                break;
            case 3:
                currentCustomer = LogIn(_customers);
                if (currentCustomer != null)
                {
                    // _menu = new MainMenu();
                    _menu.NavigateToMainMenu(currentCustomer, ref amountOfOptions);
                    // _menu.NavigateToMainMenu();
                }
                break;
            case 4:
                currentCustomer = Register(_customers);
                // _menu = new MenuBase(new MainMenu());
                _menu.NavigateToMainMenu(currentCustomer, ref amountOfOptions);
                break;
            default:
                WebShop.PrintDefaultMessage();
                break;
        }
    }


    private Customer LogIn(List<Customer> customers)
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
                    return customer;
                }
            }

            if (found == false)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid credentials.");
                Console.WriteLine();
            }
        }
        return null;
    }

    private Customer Register(List<Customer> customers)
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
                return null;
            }
        }

        // Would have liked to be able to quit at any time in here.
        bool next = false;
        string newPassword = AskCustomerInfo("password", ref next);
        string firstName = AskCustomerInfo("first name", ref next);
        string lastName = AskCustomerInfo("last name", ref next);
        string email = AskCustomerInfo("email", ref next);
        int age = AskCustomerAge(ref next);      
        string address = AskCustomerInfo("address", ref next);
        string phoneNumber = AskCustomerInfo("phone number", ref next);

        Customer newCustomer = new Customer(newUsername, newPassword, firstName, lastName,
            email, age, address, phoneNumber);
        customers.Add(newCustomer);
        // currentCustomer = newCustomer;
        Console.WriteLine();
        Console.WriteLine(
            newCustomer.Username + " successfully added and is now logged in.");
        Console.WriteLine();
        // menu.NavigateToMainMenu(newCustomer);
        return newCustomer;
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
    
    private string InputUserInfo(string infoName) 
    {
        Console.WriteLine("A keyboard appears.");
        Console.WriteLine($"Please input your {infoName}.");
        string input = Console.ReadLine();
        Console.WriteLine();
        return input;
    }

    
}