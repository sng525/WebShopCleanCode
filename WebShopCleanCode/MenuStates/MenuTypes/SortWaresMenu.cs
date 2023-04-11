using System.Runtime.InteropServices.ComTypes;
using WebShopCleanCode.Menus;

namespace WebShopCleanCode.Menu;

public class SortWaresMenu : MenuBase
{
    public SortWaresMenu()
    {
        optionList = new List<string>();
        currentMenu = "sort menu";
        optionList.Add("Sort by name, descending");
        optionList.Add("Sort by name, ascending");
        optionList.Add("Sort by price, descending");
        optionList.Add("Sort by price, ascending");
        currentChoice = 1;
    }

    public override void DisplayMenu()
    {
        Console.WriteLine(info);
        CheckIfPurchaseMenu();
        PrintOption();
        MenuBar();
        AskChoice();
        DisplayMenu();
    }
}