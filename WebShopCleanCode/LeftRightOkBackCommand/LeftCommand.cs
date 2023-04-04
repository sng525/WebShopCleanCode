namespace WebShopCleanCode.LeftRightOkBackCommand;

public class LeftCommand : IDirectionCommand
{
    public int Execute(ref int currentChoice, ref int amountOfOptions, string currentMenu)
    {
        if (currentChoice > 1)
        {
            currentChoice--;
        }

        return currentChoice;
    }
}