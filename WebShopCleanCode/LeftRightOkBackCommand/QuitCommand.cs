using System.Globalization;
using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.LeftRightOkBackCommand;

public class QuitCommand : IDirectionCommand
{

    public void Execute(MenuBase menu)
    {
        Console.WriteLine("The console powers down. You are free to leave.");
    }
}