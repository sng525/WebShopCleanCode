using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Menus;

public class PurchaseMenu : MenuBase
{
    public PurchaseMenu()
    {
        optionList = new List<string>();
        currentMenu = "purchase menu";
        info = "What would you like to purchase?";
        currentChoice = 1;
    }

    public override void DisplayMenu()
    {
        if (MenuContext.GetInstance().currentCustomer != null)
        {
            Console.WriteLine(info);
            CheckIfPurchaseMenu();
            PrintOption();
            MenuBar();
            AskChoice();
            DisplayMenu();
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("You must be logged in to purchase wares.");
            Console.WriteLine();
        }
    }
}