using WebShopCleanCode.Menus;

namespace WebShopCleanCode.Menu;

public class WaresMenu : MenuBase
{
    public override string option1 { get; set; }
    public override string option2 { get; set; }
    public override string option3 { get; set; }
    public override string option4 { get; set; }
    public override string currentMenu { get; set; }
    public override int amountOfOptions { get; set; }
    public override string info { get; set; }
    public override Customer currentCustomer { get; set; }
    public override ProductList productList { get; set; }
    public override int currentChoice { get; set; }

    public override void DisplayMenu()
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
        amountOfOptions = 4;
        currentChoice = 1;
        currentMenu = "wares menu";
        info = "What would you like to do?";
    }
}