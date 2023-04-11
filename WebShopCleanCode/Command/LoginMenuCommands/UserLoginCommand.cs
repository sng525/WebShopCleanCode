using WebShopCleanCode.MenuStates;
using WebShopCleanCode.MenuStates.MenuTypes;

namespace WebShopCleanCode.Command.LoginMenuCommands;

public class UserLoginCommand : IImplementationCommand
{
    public void DoStuff()
    {
        string username = MenuContext.GetInstance().GetUsername();
        string password = MenuContext.GetInstance().GetPassword();
        
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            Console.WriteLine();
            Console.WriteLine("Incomplete data.");
            Console.WriteLine();
        }
        else
        {
            bool found = false;
            foreach (Customer customer in MenuContext.GetInstance().GetCustomerList())
            {
                if (username.Equals(customer.Username) && customer.CheckPassword(password))
                {
                    Console.WriteLine();
                    Console.WriteLine(customer.Username + " logged in.");
                    Console.WriteLine();
                    found = true;
                    MenuContext.GetInstance().SetCurrentCustomer(customer);
                    
                    var menuState = new MenuContext();
                    menuState.SetState(new MainMenu());
                    menuState.Request();
                    break;
                }
            }
            if (found == false)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid credentials.");
                Console.WriteLine();
            }
        }
    }
}