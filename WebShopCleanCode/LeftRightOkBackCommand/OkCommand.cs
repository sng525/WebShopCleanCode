using System.Windows.Input;
using ICommand = WebShopCleanCode.Command.ICommand;

namespace WebShopCleanCode.LeftRightOkBackCommand;

public class OkCommand : IDirectionCommand
{
    private Dictionary<(string currentMenu, int currentChoice), ICommand> _commandDict;
    Customer currentCustomer;

    public OkCommand(Dictionary<(string currentMenu, int currentChoice), ICommand> commandDict)
    {
        _commandDict = commandDict;
    }

    public int Execute(ref int currentChoice, ref int amountOfChoices, string currentMenu)
    {
        if (_commandDict.TryGetValue((currentMenu, currentChoice), out var command))
        {
            command.Execute(currentCustomer, ref currentChoice, ref amountOfChoices);
        }
        else
        {
            WebShop.PrintDefaultMessage();
        }

        return currentChoice;
    }
    
}