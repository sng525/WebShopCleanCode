namespace WebShopCleanCode.Menus;

public class PurchaseMenu : MenuBase
{
    public override string option1 { get; set; }
    public override string option2 { get; set; }
    public override string option3 { get; set; }
    public override string option4 { get; set; }
    public override string currentMenu { get; set; } = "purchase menu";
    public override int amountOfOptions { get; set; }
    public override string info { get; set; }
    public override Customer currentCustomer { get; set; }

    public override ProductList productList { get; set; }
    public override int currentChoice { get; set; }

    public override void DisplayMenu()
    {
        if (currentCustomer != null)
        {
            currentMenu = "purchase menu";
            info = "What would you like to purchase?";
            currentChoice = 1;
            amountOfOptions = productList.products.Count;
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