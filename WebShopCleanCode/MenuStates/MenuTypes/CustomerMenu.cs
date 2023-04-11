namespace WebShopCleanCode.MenuStates.MenuTypes;

public class CustomerMenu : MenuBase
{
    public CustomerMenu()
    {
        optionList = new List<string>
        {
            "See your orders",
            "See your info",
            "Add funds"
        };
        info = "What would you like to do?";
        currentMenu = "customer menu";
        currentChoice = 1;
    }

    public override void DisplayMenu()
    {
        if (MenuContext.GetInstance().GetCurrentCustomer() != null)
        {
            Console.WriteLine(info);
            PrintOption();
            MenuBar();
            CheckLogInStatus();
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