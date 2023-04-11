using WebShopCleanCode.MenuStates;
using WebShopCleanCode.MenuStates.MenuTypes;

namespace WebShopCleanCode.LeftRightOkBackCommand;

public class BackCommand : IDirectionCommand
{
    public void Execute(MenuBase menu)
    {
        MenuContext menuState = new MenuContext();
        
        if (menu.currentMenu.Equals("main menu"))
        {
            Console.WriteLine();
            Console.WriteLine("You're already on the main menu.");
            Console.WriteLine();
        }
        else if (menu.currentMenu.Equals("purchase menu"))
        {
            menuState.SetState(new WaresMenu());
            menuState.Request();
        }
        else
        {
            menuState.SetState(new MainMenu());
            menuState.Request();
        }
    }
}