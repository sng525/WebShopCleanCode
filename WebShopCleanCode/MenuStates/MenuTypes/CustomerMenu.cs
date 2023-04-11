using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Menu;

public class CustomerMenu : MenuBase
{
    public CustomerMenu()
    {
        optionList = new List<string>();
        optionList.Add("See your orders");
        optionList.Add("Set your info");
        optionList.Add("Add funds");
        optionList.Add("");
        info = "What would you like to do?";
        currentMenu = "customer menu";
        currentChoice = 1;
    }

    public override void DisplayMenu()
    {
        if (MenuContext.GetInstance().GetCurrentCustomer() != null)
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
            Console.WriteLine("Nobody is logged in.");
            Console.WriteLine();
            
            MenuContext menuState = new MenuContext();
            menuState.SetState(new MainMenu());
            menuState.Request();
        }
    }
}