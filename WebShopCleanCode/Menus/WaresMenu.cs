using WebShopCleanCode.Menus;

namespace WebShopCleanCode.Menu;

public class WaresMenu : MenuBase
{
    public override string option1 { get; set; }
    public override string option2 { get; set; }
    public override string option3 { get; set; }
    public override string option4 { get; set; }
    public override string currentMenu { get; set; }
    // public int amountOfOptions { get; set; }
    public override string info { get; set; }
    // public Customer currentCustomer { get; }
    // public ProductList productList { get; }
   //  public int currentChoice { get; set; }

    public override void DisplayMenu(Customer currentCustomer, ref int amountOfOptions)
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
        // amountOfOptions = 4;
        // currentChoice = 1;
        currentMenu = "wares menu";
        info = "What would you like to do?";
    }
}