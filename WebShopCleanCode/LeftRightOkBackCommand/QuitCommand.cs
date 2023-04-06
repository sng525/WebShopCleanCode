namespace WebShopCleanCode.LeftRightOkBackCommand;

public class QuitCommand : IDirectionCommand
{
    public void Execute()
    {
        Console.WriteLine("The console powers down. You are free to leave.");
    }
}