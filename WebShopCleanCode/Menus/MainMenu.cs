using WebShopCleanCode.Menus;

namespace WebShopCleanCode.Menu;

public class MainMenu : MenuBase
{
    public override string option1 { get; set; } = "See Wares";
    public override string option2 { get; set; } = "Customer Info";
    public override string option3 { get; set; } = "Login";
    public override string option4 { get; set; } = "";
    public override string currentMenu { get; set; } = "main menu";
    // public int amountOfOptions { get; set; } = 3;
    public override string info { get; set; } = "What would you like to do?";
    // public Customer currentCustomer { get; }
    // public ProductList productList { get; }
    // public int currentChoice { get; set; }

    public override void DisplayMenu(Customer currentCustomer, ref int amountOfOptions)
    {
        Console.WriteLine(info);
        Console.WriteLine("1: " + option1);
        Console.WriteLine("2: " + option2);
        option3 = currentCustomer == null ? "Login" : "Logout";
        if (amountOfOptions > 2)
        {
            Console.WriteLine("3: " + option3);
        }

        if (amountOfOptions > 3)
        {
            Console.WriteLine("4: " + option4);
        }
    }
    
    public void NavigateToMainMenu(Customer currentCustomer, ref int amountOfOptions)
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
        info = "What would you like to do?";
        currentMenu = "main menu";
        // currentChoice = 1;
        amountOfOptions = 3;
    }
}