namespace WebShopCleanCode.MenuStates;

public class MenuContext
{
    public IMenu menuState { get; set; }
    public static MenuContext instance;
    public Customer currentCustomer { get; set; }
    public List<Customer> customerList = new List<Customer>();
    public string username;
    public string password;
    
    Database database = new Database();
    
    public static MenuContext GetInstance() {
        if (instance == null) {
            instance = new MenuContext();
        }
        return instance;
    }

    public void SetState(IMenu menuState)
    {
        this.menuState = menuState;
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
        database = new Database();
        customerList = database.GetCustomers();
        return customerList;
    }

    public string GetUsername()
    {
        return username;
    }
    
    public void SetUsername(string username)
    {
        this.username = username;
    }
    
    public string GetPassword()
    {
        return password;
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