using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Menu;

public class LoginMenu : MenuBase
{
    public LoginMenu()
    {
        optionList = new List<string>();

        optionList.Add("Set Username");
        optionList.Add("Set Password");
        optionList.Add("Login");
        optionList.Add("Register");
        currentChoice = 1;
        info = "Please submit username and password.";
        currentMenu = "login menu";
        MenuContext.GetInstance().currentCustomer = null;
        currentChoice = 1;
    }
    public override void DisplayMenu()
    {
        if (MenuContext.GetInstance().GetCurrentCustomer() == null)
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
            optionList[4] = "Logout";
            PrintOption();
            Console.WriteLine();
            Console.WriteLine(MenuContext.GetInstance().currentCustomer.Username + " logged out.");
            Console.WriteLine();
        }
    }
}


