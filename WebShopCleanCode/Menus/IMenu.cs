namespace WebShopCleanCode.Menus;

public interface IMenu
{
    string currentMenu { get; set; }
    int amountOfOptions { get; set; }
    string info { get; }
    Customer currentCustomer { get; }
    ProductList productList { get; }
    string option1 { get; set; }
    string option2 { get; set; }
    string option3 { get; set; }
    string option4 { get; set; }
    void DisplayMenu();
}