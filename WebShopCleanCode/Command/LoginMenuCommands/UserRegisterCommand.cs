using WebShopCleanCode.MenuStates;
namespace WebShopCleanCode.Command.LoginMenuCommands;

public class UserRegisterCommand : IImplementationCommand
{
    public void DoStuff()
    {
        Console.WriteLine("Please write your username.");
        var newUsername = Console.ReadLine();
        foreach (Customer customer in MenuContext.GetInstance().GetCustomerList())
        {
            if (customer.Username.Equals(MenuContext.GetInstance().username))
            {
                Console.WriteLine();
                Console.WriteLine("Username already exists.");
                Console.WriteLine();
            }
        }

        // Would have liked to be able to quit at any time in here.
        bool next = false;
        string newPassword = AskCustomerInfo("password", ref next);
        string firstName = AskCustomerInfo("first name", ref next);
        string lastName = AskCustomerInfo("last name", ref next);
        string email = AskCustomerInfo("email", ref next);
        int age = AskCustomerAge(ref next);
        string address = AskCustomerInfo("address", ref next);
        string phoneNumber = AskCustomerInfo("phone number", ref next);

        CustomerBuilder customerBuilder = new CustomerBuilder();
        Customer newCustomer = customerBuilder.SetUsername(newUsername)
            .SetPassword(newPassword)
            .SetFirstName(firstName)
            .SetLastName(lastName)
            .SetEmail(email)
            .SetAge(age)
            .SetAddress(address)
            .SetPassword(phoneNumber).BuildCustomer();
        
        MenuContext menuState = new MenuContext();
        menuState.GetCustomerList().Add(newCustomer);
        menuState.SetCurrentCustomer(newCustomer);
        
        Console.WriteLine();
        Console.WriteLine(newCustomer.Username + " successfully added and is now logged in.");
        Console.WriteLine();
        
        menuState.SetState(new MainMenu());
        menuState.Request();
    }

    private int AskCustomerAge(ref bool next)
    {
        string choice;
        int age = -1;
        while (true)
        {
            Console.WriteLine("Do you want an age? y/n");
            choice = Console.ReadLine();
            if (choice.Equals("y"))
            {
                while (true)
                {
                    Console.WriteLine("Please write your age.");
                    string ageString = Console.ReadLine();
                    try
                    {
                        age = int.Parse(ageString);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please write a number.");
                        Console.WriteLine();
                        continue;
                    }

                    next = true;
                    break;
                }
            }

            if (choice.Equals("n") || next)
            {
                next = false;
                break;
            }

            Console.WriteLine();
            Console.WriteLine("y or n, please.");
            Console.WriteLine();
        }

        return age;
    }
    private string AskCustomerInfo(string infoMessage, ref bool next)
    {
        string choice;
        string infoItem = null;
        while (true)
        {
            Console.WriteLine($"Do you want a {infoMessage}? y/n");
            choice = Console.ReadLine();
            if (choice.Equals("y"))
            {
                while (true)
                {
                    Console.WriteLine($"Please write your {infoMessage}.");
                    infoItem = Console.ReadLine();
                    if (infoItem.Equals(""))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please actually write something.");
                        Console.WriteLine();
                    }
                    else
                    {
                        next = true;
                        break;
                    }
                }
            }

            if (choice.Equals("n") || next)
            {
                next = false;
                break;
            }

            Console.WriteLine();
            Console.WriteLine("y or n, please.");
            Console.WriteLine();
        }

        return infoItem;
    }
}