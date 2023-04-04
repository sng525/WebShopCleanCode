namespace WebShopCleanCode.LeftRightOkBackCommand;

public class QuitCommand : IDirectionCommand
{
    public int Execute(ref int currentChoice, ref int amountOfOptions, string currentMenu)
    {
        Console.WriteLine("The console powers down. You are free to leave.");
        return -1;
    }
}