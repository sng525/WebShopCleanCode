namespace WebShopCleanCode.MenuStates.MenuTypes;

public class LoginMenu : MenuBase
{
    public LoginMenu()
    {
        optionList = new List<string>();
        optionList.Add("Set Username");
        optionList.Add("Set Password");
        if (MenuContext.GetInstance().GetCurrentCustomer() == null)
        {
            optionList.Add("Login");
            optionList.Add("Register");
        }
        else
        {
            optionList.Add("Logout");
        }

        currentChoice = 1;
        info = "Please submit username and password.";
        currentMenu = "login menu";
    }
    public override void DisplayMenu()
    {
        if (MenuContext.GetInstance().GetCurrentCustomer() == null)
        {
            Console.WriteLine(info);
            PrintOption();
            MenuBar();
            AskChoice();
            DisplayMenu();
        }
        else
        {
            PrintOption();
            MenuContext.GetInstance().SetCurrentCustomer(null);
            Console.WriteLine();
            Console.WriteLine(MenuContext.GetInstance().currentCustomer.Username + " logged out.");
            Console.WriteLine();
        }
    }
}


