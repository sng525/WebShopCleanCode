namespace WebShopCleanCode.MenuStates.MenuTypes;

public class MainMenu : MenuBase
{
    public MainMenu()
    {
        optionList = new List<string>();
        optionList.Add("See Wares");
        optionList.Add("Customer Info");
        optionList.Add(MenuContext.GetInstance().currentCustomer == null ? "Login" : "Logout");
        info = "What would you like to do?";
        currentMenu = "main menu";
        currentChoice = 1;
    }
    public override void DisplayMenu()
    {
        Console.WriteLine(info);
        PrintOption();
        MenuBar();
        CheckLogInStatus();
        AskChoice();
        DisplayMenu();
    }
}