using WebShopCleanCode.Menus;

namespace WebShopCleanCode.Menu;

public class LoginMenu : MenuBase
{
    public override string option1 { get; set; }
    public override string option2 { get; set; }
    public override string option3 { get; set; }
    public override string option4 { get; set; }
    public override string currentMenu { get; set; } = "login menu";
    // public int amountOfOptions { get; set; }
    public override string info { get; set; }
    // public Customer currentCustomer { get; set; }
    // public ProductList productList { get; }
    // public int currentChoice { get; set; }
    
    public virtual void DisplayMenu(Customer currentCustomer, ref int amountOfOptions)
    {
        if (currentCustomer == null)
        {
            option1 = "Set Username";
            option2 = "Set Password";
            option3 = "Login";
            option4 = "Register";
            amountOfOptions = 4;
            // currentChoice = 1;
            info = "Please submit username and password.";
            // username = null;
            // password = null;
            currentMenu = "login menu";
        }
        else
        {
            option3 = "Login";
            Console.WriteLine();
            Console.WriteLine(currentCustomer.Username + " logged out.");
            Console.WriteLine();
            currentCustomer = null;
            // currentChoice = 1;

        }
    }
    
    public void NavigateFromWaresMenuToLoginMenu(Customer currentCustomer)
    {
        if (currentCustomer == null)
        {
            option1 = "Set Username";
            option2 = "Set Password";
            option3 = "Login";
            option4 = "Register";
            // amountOfOptions = 4;
            // currentChoice = 1;
        }
        else
        {
            option4 = "Login";
            currentCustomer = null;
            Console.WriteLine();
            Console.WriteLine(currentCustomer.Username + " logged out.");
            Console.WriteLine();
            // currentChoice = 1;
        }
    }
}