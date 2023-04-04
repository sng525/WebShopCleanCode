namespace WebShopCleanCode.LeftRightOkBackCommand;

public class RightCommand : IDirectionCommand
{
    public int Execute(ref int currentChoice, ref int amountOfOptions, string currentMenu)
    {
        if (currentChoice < amountOfOptions)
        {
            currentChoice++;
        }

        return currentChoice;
    }
}