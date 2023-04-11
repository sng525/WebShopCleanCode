using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command.LoginMenuCommands;

public class UserLoginCommand : IImplementationCommand
{
    public void DoStuff()
    {
        MenuContext menuState = new MenuContext();

        if (MenuContext.GetInstance().username == null || MenuContext.GetInstance().password == null)
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
                if (MenuContext.GetInstance().username.Equals(customer.Username) && customer.CheckPassword(MenuContext.GetInstance().username))
                {
                    Console.WriteLine();
                    Console.WriteLine(customer.Username + " logged in.");
                    Console.WriteLine();
                    found = true;
                    MenuContext.GetInstance().SetCurrentCustomer(customer);
                    menuState.SetState(new MainMenu());
                    menuState.Request();
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