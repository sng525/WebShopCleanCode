using WebShopCleanCode.Menu;
using WebShopCleanCode.Menus;

namespace WebShopCleanCode.MenuStates;

public class MenuContext
{
    public IMenu menuState { get; set; }
    public static MenuContext instance;
    public Customer currentCustomer { get; set; } = null;
    public List<Customer> customerList = new List<Customer>();
    public string username;
    public string password;
    
    public static MenuContext GetInstance() {
        if (instance == null) {
            instance = new MenuContext();
        }
        return instance;
    }

    public void SetState(IMenu menustate)
    {
        menuState = menustate;
    }

    public void Request()
    {
        menuState.DisplayMenu();
    }

    public Customer GetCurrentCustomer()
    {
        return currentCustomer;
    }

    public void SetCurrentCustomer(Customer customer)
    {
        currentCustomer = customer;
    }

    public List<Customer> GetCustomerList()
    {
        return customerList;
    }

    public void SetUsername(string username)
    {
        this.username = username;
    }
    
    public void SetPassword(string password)
    {
        this.password = password;
    }

    public string InputUserInfo(string infoName)
    {
        Console.WriteLine("A keyboard appears.");
        Console.WriteLine($"Please input your {infoName}.");
        var input = Console.ReadLine();
        Console.WriteLine();
        return input;
    }


}