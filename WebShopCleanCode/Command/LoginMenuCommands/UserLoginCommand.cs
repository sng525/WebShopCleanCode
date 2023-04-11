using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode.Command.LoginMenuCommands;

public class UserLoginCommand : IImplementationCommand
{
    public void DoStuff()
    {

        if (MenuContext.GetInstance().GetUsername() == null || MenuContext.GetInstance().GetPassword() == null)
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
                if (MenuContext.GetInstance().GetUsername().Equals(customer.Username) && customer.CheckPassword(MenuContext.GetInstance().GetPassword()))
                {
                    Console.WriteLine();
                    Console.WriteLine(customer.Username + " logged in.");
                    Console.WriteLine();
                    found = true;
                    MenuContext.GetInstance().SetCurrentCustomer(customer);
                    
                    var menuState = new MenuContext();
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