using System.Windows.Input;
using WebShopCleanCode.Command;
using WebShopCleanCode.LeftRightOkBackCommand;
using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode;

public abstract class MenuBase : IMenu
{
    public List<string> optionList = new List<string>();
    public string currentMenu { get; set; }
    public string info { get; set; }
    public int currentChoice { get; set; }
    public ProductList productList = new ProductList();

    private Dictionary<string, IDirectionCommand> directionCommand = new Dictionary<string, IDirectionCommand>();
    private Dictionary<string, IMenuCommand> commandDict = new Dictionary<string, IMenuCommand>();

    public virtual void DisplayMenu()
    {
        throw new NotImplementedException();
    }

    public void LeftCommandFunction()
    {
        if (currentChoice > 1)
        {
            currentChoice--;
        }
    }
    

    public void MenuBar()
    {
        /*Dictionary<string, ThreadStart> newDirectionCommand = new Dictionary<string, ThreadStart>();
        newDirectionCommand.Add("left", LeftCommandFunction);*/
        
        
        

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

        for (int i = 0; i < optionList.Count; i++)
        {
            Console.Write(i + 1 + "\t");
        }

        Console.WriteLine();
        for (int i = 1; i < currentChoice; i++)
        {
            Console.Write("\t");
        }

        Console.WriteLine("|");

        Console.WriteLine("Your buttons are Left, Right, OK, Back and Quit.");

        CheckLogInStatus();
    }

    public void AskChoice()
    {
        string choice = Console.ReadLine().ToLower();

        if (directionCommand.TryGetValue(choice.ToLowerInvariant(), out var command))
        {
            command.Execute(this);
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

    public void PurchaseWare()
    {
        int index = currentChoice - 1;
        var product = productList.products[index];
        if (product.InStock())
        {
            if (MenuContext.GetInstance().currentCustomer.CanAfford(product.Price))
            {
                MenuContext.GetInstance().currentCustomer.Funds -= product.Price;
                product.NrInStock--;
                MenuContext.GetInstance().currentCustomer.Orders
                    .Add(new Order(product.Name, product.Price, DateTime.Now));
                Console.WriteLine();
                Console.WriteLine("Successfully bought " + product.Name);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You cannot afford.");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Not in stock.");
            Console.WriteLine();
        }
    }

    public virtual void SeeAllWares()
    {
        throw new NotImplementedException();
    }

    public void bubbleSort(string variable, bool ascending)
    {
        if (variable.Equals("name"))
        {
            int length = productList.products.Count;
            for (int i = 0; i < length - 1; i++)
            {
                bool sorted = true;
                int length2 = length - i;
                for (int j = 0; j < length2 - 1; j++)
                {
                    if (ascending)
                    {
                        if (productList.products[j].Name.CompareTo(productList.products[j + 1].Name) < 0)
                        {
                            Product temp = productList.products[j];
                            productList.products[j] = productList.products[j + 1];
                            productList.products[j + 1] = temp;
                            sorted = false;
                        }
                    }
                    else
                    {
                        if (productList.products[j].Name.CompareTo(productList.products[j + 1].Name) > 0)
                        {
                            Product temp = productList.products[j];
                            productList.products[j] = productList.products[j + 1];
                            productList.products[j + 1] = temp;
                            sorted = false;
                        }
                    }
                }

                if (sorted == true)
                {
                    break;
                }
            }
        }
        else if (variable.Equals("price"))
        {
            int length = productList.products.Count;
            for (int i = 0; i < length - 1; i++)
            {
                bool sorted = true;
                int length2 = length - i;
                for (int j = 0; j < length2 - 1; j++)
                {
                    if (ascending)
                    {
                        if (productList.products[j].Price > productList.products[j + 1].Price)
                        {
                            Product temp = productList.products[j];
                            productList.products[j] = productList.products[j + 1];
                            productList.products[j + 1] = temp;
                            sorted = false;
                        }
                    }
                    else
                    {
                        if (productList.products[j].Price < productList.products[j + 1].Price)
                        {
                            Product temp = productList.products[j];
                            productList.products[j] = productList.products[j + 1];
                            productList.products[j + 1] = temp;
                            sorted = false;
                        }
                    }
                }

                if (sorted == true)
                {
                    break;
                }
            }
        }
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

    public void CheckIfPurchaseMenu()
    {
        if (currentMenu.Equals("purchase menu"))
        {
            productList.GetProductList(MenuContext.GetInstance().currentCustomer, optionList.Count);
        }
    }

    public void WareSortedNotification()
    {
        Console.WriteLine();
        Console.WriteLine("Wares sorted.");
        Console.WriteLine();
    }

    public static void PrintDefaultMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Not an option.");
        Console.WriteLine();
    }
}