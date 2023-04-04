namespace WebShopCleanCode.LeftRightOkBackCommand;

public interface IDirectionCommand
{
    int Execute(ref int currentChoice, ref int amountOfOptions, string currentMenu);
}



