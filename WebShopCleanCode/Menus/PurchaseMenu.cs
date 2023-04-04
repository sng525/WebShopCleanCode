namespace WebShopCleanCode.Menus;

public class PurchaseMenu : MenuBase
{
    public override string option1 { get; set; }
    public override string option2 { get; set; }
    public override string option3 { get; set; }
    public override string option4 { get; set; }
    public override string currentMenu { get; set; } = "purchase menu";
    // public int amountOfOptions { get; set; }
    public override string info { get; set; }
    // public Customer currentCustomer { get; }
    // public ProductList productList { get; }
    // public int currentChoice { get; set; }

    public virtual void DisplayMenu(Customer currentCustomer, ref int amountOfOptions)
    {
        if (currentCustomer != null)
        {
            currentMenu = "purchase menu";
            info = "What would you like to purchase?";
            // currentChoice = 1;
            // amountOfOptions = products.Count;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("You must be logged in to purchase wares.");
            Console.WriteLine();
            // currentChoice = 1;
        }
    }
}