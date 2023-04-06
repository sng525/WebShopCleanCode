using WebShopCleanCode.Menus;

namespace WebShopCleanCode.Menu;

public class SortWaresMenu : MenuBase
{
    public override string option1 { get; set; }
    public override string option2 { get; set; }
    public override string option3 { get; set; }
    public override string option4 { get; set; }
    public override string currentMenu { get; set; } = "sort menu";
    public override int amountOfOptions { get; set; }
    public override string info { get; set; }
    public override Customer currentCustomer { get; set; }
    public override ProductList productList { get; set; }
    public override int currentChoice { get; set; }

    public override void DisplayMenu()
    {
        option1 = "Sort by name, descending";
        option2 = "Sort by name, ascending";
        option3 = "Sort by price, descending";
        option4 = "Sort by price, ascending";
        amountOfOptions = 4;
    }
}