namespace WebShopCleanCode.MenuStates.MenuTypes;

public class WaresMenu : MenuBase
{
    public WaresMenu()
    {
        optionList = new List<string>();
        optionList.Add("See all wares");
        optionList.Add("Purchase a ware");
        optionList.Add("Sort wares");
        if (MenuContext.GetInstance().currentCustomer == null)
        {
            optionList.Add("Login");
        }
        else
        {
            optionList.Add("Logout");
        }
        info = "What would you like to do?";
        currentMenu = "wares menu";
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
    
    public override void SeeAllWares()
    {
        Console.WriteLine();
        foreach (Product product in productList.products)
        {
            product.PrintInfo();
        }

        Console.WriteLine();
    }
}