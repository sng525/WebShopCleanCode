using System.Windows.Input;
using WebShopCleanCode.Menus;
using ICommand = WebShopCleanCode.Command.ICommand;

namespace WebShopCleanCode.LeftRightOkBackCommand;

public class OkCommand : IDirectionCommand
{
    private Dictionary<(string currentMenu, int currentChoice), ICommand> _commandDict;
    private IMenu _menu;

    public OkCommand(IMenu menu, Dictionary<(string currentMenu, int currentChoice), ICommand> commandDict)
    {
        _menu = menu;
        _commandDict = commandDict;
    }

    public void Execute()
    {
        if (_commandDict.TryGetValue((_menu.currentMenu, _menu.currentChoice), out var command))
        {
            command.Execute();
        }
        else
        {
            WebShop.PrintDefaultMessage();
        }
    }
    
}