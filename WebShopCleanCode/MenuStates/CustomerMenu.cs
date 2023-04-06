using WebShopCleanCode.Menus;

namespace WebShopCleanCode.Menu;

public class CustomerMenu : MenuBase
{
    public override string option1 { get; set; }
    public override string option2 { get; set; }
    public override string option3 { get; set; }
    public override string option4 { get; set; }
    public override string currentMenu { get; set; } = "customer menu";
    public override int amountOfOptions { get; set; }
    public override string info { get; set; }
    public override Customer currentCustomer { get; set; }
    public override int currentChoice { get; set; }
    
    // public ProductList productList { get; }

    public override void DisplayMenu()
    {
        if (currentCustomer != null)
        {
            option1 = "See your orders";
            option2 = "Set your info";
            option3 = "Add funds";
            option4 = "";
            amountOfOptions = 3;
            currentChoice = 1;
            info = "What would you like to do?";
            currentMenu = "customer menu";
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Nobody is logged in.");
            Console.WriteLine();
        }
    }
}