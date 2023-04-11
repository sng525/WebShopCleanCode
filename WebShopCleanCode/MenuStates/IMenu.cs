namespace WebShopCleanCode.MenuStates;

public interface IMenu
{
    void DisplayMenu();
    void PurchaseWare();
    void SeeAllWares();
    void bubbleSort(string variable, bool ascending);
    void WareSortedNotification();
}