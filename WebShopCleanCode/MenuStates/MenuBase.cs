using WebShopCleanCode.LeftRightOkBackCommand;

namespace WebShopCleanCode.MenuStates;

public abstract class MenuBase : IMenu
{
    public List<string> optionList = new List<string>();
    public string currentMenu { get; set; }
    public string info { get; set; }
    public int currentChoice { get; set; }
    public ProductList productList = new ProductList();
    private Dictionary<string, IDirectionCommand> directionCommand = new Dictionary<string, IDirectionCommand>();

    public virtual void DisplayMenu()
    {
        throw new NotImplementedException();
    }

    public void MenuBar()
    {
        directionCommand = new Dictionary<string, IDirectionCommand>
        {
            { "left", new LeftCommand() },
            { "l", new LeftCommand() },
            { "right", new RightCommand() },
            { "r", new RightCommand() },
            { "ok", new OkCommand() },
            { "k", new OkCommand() },
            { "o", new OkCommand() },
            { "back", new BackCommand() },
            { "b", new BackCommand() },
            { "quit", new QuitCommand() },
            { "q", new QuitCommand() }
        };

        if (currentMenu == "purchase menu")
        {
            for (int i = 0; i < productList.products.Count; i++)
            {
                Console.Write(i + 1 + "\t");
            }
        }
        else
        {
            for (int i = 0; i < optionList.Count; i++)
            {
                Console.Write(i + 1 + "\t");
            }
        }

        Console.WriteLine();
        for (int i = 1; i < currentChoice; i++)
        {
            Console.Write("\t");
        }

        Console.WriteLine("|");

        Console.WriteLine("Your buttons are Left, Right, OK, Back and Quit.");
    }

    public void AskChoice()
    {
        string choice = Console.ReadLine().ToLower();

        if (directionCommand.TryGetValue(choice.ToLowerInvariant(), out var command))
        {
            command.Execute(this);
            if (choice == "quit" || choice == "q")
            {
                Environment.Exit(0);
            }
        }
        else
        {
            Console.WriteLine("That is not an applicable option.");
        }
    }

    public void PrintOption()
    {
        for (int i = 0; i < optionList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {optionList[i]}");
        }
    }

    public virtual void PurchaseWare()
    {
        throw new NotImplementedException();
    }

    public virtual void SeeAllWares()
    {
        throw new NotImplementedException();
    }
    
    public virtual void WareSortedNotification()
    {
        throw new NotImplementedException();
    }

    public virtual void bubbleSort(string variable, bool ascending)
    {
        throw new NotImplementedException();
    }

    public void CheckLogInStatus()
    {
        if (MenuContext.GetInstance().currentCustomer != null)
        {
            Console.WriteLine("Current user: " + MenuContext.GetInstance().currentCustomer.Username);
        }
        else
        {
            Console.WriteLine("Nobody logged in.");
        }
    }

    public static void PrintDefaultMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Not an option.");
        Console.WriteLine();
    }
}