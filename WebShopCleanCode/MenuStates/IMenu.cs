namespace WebShopCleanCode.Menus;

public interface IMenu
{
    int currentChoice { get; set; }
    Customer currentCustomer { get; set; }
    ProductList productList { get; set; }
    int amountOfOptions { get; set; }
    string currentMenu { get; set; }
    void DisplayMenu();
    void MenuBar();
}