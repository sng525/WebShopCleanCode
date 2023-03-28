namespace WebShopCleanCode;

public class Menu
{
    public string currentMenu { get; set; }
    public string option1 { get; set; }
    public string option2 { get; set; }
    public string option3 { get; set; }
    public string option4 { get; set; }
    
    Customer customer;
    public int currentChoice { get; set; }
    public int amountOfOptions { get; set; }
    
    public Menu()
    {
        currentMenu = "main menu";
        currentChoice = 1;
        amountOfOptions = 3;
        option1 = "See Wares";
        option2 = "Customer Info";
        option3 = "Login";
        option4 = "";
        currentChoice = 1;
        amountOfOptions = 3;
    }

    public void MainMenu()
    {
        Console.WriteLine("1: " + option1);
        Console.WriteLine("2: " + option2);
        if (amountOfOptions > 2)
        {
            Console.WriteLine("3: " + option3);
        }

        if (amountOfOptions > 3)
        {
            Console.WriteLine("4: " + option4);
        }
    }
    
    public void MenuBar()
    {
        for (int i = 0; i < amountOfOptions; i++)
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
    }
    
    public void NavigateToMainMenu(){
        option1 = "See Wares";
        option2 = "Customer Info";
        if (customer == null)
        {
            option3 = "Login";
        }
        else
        {
            option3 = "Logout";
        }
        currentMenu = "main menu";
        currentChoice = 1;
        amountOfOptions = 3;
    }
    
    public void NavigateToWaresMenu()
    {
        option1 = "See all wares";
        option2 = "Purchase a ware";
        option3 = "Sort wares";
        if (customer == null)
        {
            option4 = "Login";
        }
        else
        {
            option4 = "Logout";
        }

        amountOfOptions = 4;
        currentChoice = 1;
        currentMenu = "wares menu";
    }
    
    public void SortWaresMenu()
    {
        option1 = "Sort by name, descending";
        option2 = "Sort by name, ascending";
        option3 = "Sort by price, descending";
        option4 = "Sort by price, ascending";
        currentMenu = "sort menu";
        currentChoice = 1;
        amountOfOptions = 4;
    }
}