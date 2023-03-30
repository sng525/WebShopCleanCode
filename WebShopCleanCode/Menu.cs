namespace WebShopCleanCode;

public class Menu
{
    public string currentMenu { get; set; } = "main menu";
    public string option1 { get; set; } = "See Wares";
    public string option2 { get; set; } = "Customer Info";
    public string option3 { get; set; } = "Login";
    public string option4 { get; set; } = "";
    public int currentChoice { get; set; } = 1;
    public int amountOfOptions { get; set; } = 3;
    public string Info { get; set; } = "What would you like to do?";

    public void MainMenu()
    {
        Console.WriteLine("1: " + option1);
        Console.WriteLine("2: " + option2);
        if (amountOfOptions > 2)
        {
            Console.WriteLine("3: " + option3);
        }

        if (amountOfOptions > 3)
        {
            Console.WriteLine("4: " + option4);
        }
    }

    public void NavigateToMainMenu(Customer currentCustomer)
    {
        option1 = "See Wares";
        option2 = "Customer Info";
        if (currentCustomer == null)
        {
            option3 = "Login";
        }
        else
        {
            option3 = "Logout";
        }

        currentMenu = "main menu";
        currentChoice = 1;
        amountOfOptions = 3;
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
    
    public void WaresMenu(string info, Customer currentCustomer)
    {
        option1 = "See all wares";
        option2 = "Purchase a ware";
        option3 = "Sort wares";
        if (currentCustomer == null)
        {
            option4 = "Login";
        }
        else
        {
            option4 = "Logout";
        }

        this.Info = info;
        amountOfOptions = 4;
        currentChoice = 1;
        currentMenu = "wares menu";
    }

    public void SortWaresMenu(string info)
    {
        option1 = "Sort by name, descending";
        option2 = "Sort by name, ascending";
        option3 = "Sort by price, descending";
        option4 = "Sort by price, ascending";
        currentMenu = "sort menu";
        currentChoice = 1;
        amountOfOptions = 4;
        this.Info = info;
    }

    public void CustomerMenu(string info, Customer currentCustomer)
    {
        if (currentCustomer != null)
        {
            option1 = "See your orders";
            option2 = "Set your info";
            option3 = "Add funds";
            option4 = "";
            amountOfOptions = 3;
            currentChoice = 1;
            this.Info = info;
            currentMenu = "customer menu";
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Nobody is logged in.");
            Console.WriteLine();
        }
    }

    public void LogInMenu(string info, Customer currentCustomer)
    {
        if (currentCustomer == null)
        {
            option1 = "Set Username";
            option2 = "Set Password";
            option3 = "Login";
            option4 = "Register";
            amountOfOptions = 4;
            currentChoice = 1;

            // username = null;
            // password = null;
            this.Info = info;
            currentMenu = "login menu";
        }
        else
        {
            option3 = "Login";
            Console.WriteLine();
            Console.WriteLine(currentCustomer.Username + " logged out.");
            Console.WriteLine();
            currentChoice = 1;
            currentCustomer = null;
        }
    }

    public void AddFund(Customer currentCustomer)
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

    public void NavigateFromWaresMenuToLoginMenu(string info, Customer currentCustomer)
    {
        if (currentCustomer == null)
        {
            option1 = "Set Username";
            option2 = "Set Password";
            option3 = "Login";
            option4 = "Register";
            amountOfOptions = 4;
            this.Info = info;
            currentChoice = 1;
            currentMenu = "login menu";
        }
        else
        {
            option4 = "Login";
            Console.WriteLine();
            Console.WriteLine(currentCustomer.Username + " logged out.");
            Console.WriteLine();
            currentCustomer = null;
            currentChoice = 1;
        }
    }
    
    public void PurchaseWareMenu(Customer currentCustomer, List<Product> products, string info)
    {
        if (currentCustomer != null)
        {
            currentMenu = "purchase menu";
            this.Info = info;
            currentChoice = 1;
            amountOfOptions = products.Count;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("You must be logged in to purchase wares.");
            Console.WriteLine();
            currentChoice = 1;
        }
    }
}