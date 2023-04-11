namespace WebShopCleanCode;

public class CustomerBuilder
{
    string Username;
    string password;
    string FirstName;
    string LastName;
    string Email;
    int Age;
    string Address;
    string PhoneNumber;
    int Funds;
    List<Order> Orders;

    public CustomerBuilder()
    {
        string Username = "";
        string password = "";
        string FirstName = "";
        string LastName = "";
        string Email = "";
        int Age = 0;
        string Address = "";
        string PhoneNumber = "";
        int Funds = 0;
        Orders = new List<Order>();
    }

    public CustomerBuilder SetUsername(string username)
    {
        Username = username;
        return this;
    }
    public CustomerBuilder SetPassword(string password)
    {
        this.password = password;
        return this;
    }
    public CustomerBuilder SetFirstName(string firstName)
    {
        FirstName = firstName;
        return this;
    }
    public CustomerBuilder SetLastName(string lastName)
    {
        LastName = lastName;
        return this;
    }
    public CustomerBuilder SetEmail(string email)
    {
        Email = email;
        return this;
    }
    public CustomerBuilder SetAge(int age)
    {
        Age = age;
        return this;
    }
    public CustomerBuilder SetAddress(string address)
    {
        Address = address;
        return this;
    }
    public CustomerBuilder SetPhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
        return this;
    }
    public CustomerBuilder SetFunds(int funds)
    {
        Funds = funds;
        return this;
    }

    public Customer BuildCustomer()
    {
        return new Customer(Username, password, FirstName, LastName, Email, Age, Address, PhoneNumber);
    }
}