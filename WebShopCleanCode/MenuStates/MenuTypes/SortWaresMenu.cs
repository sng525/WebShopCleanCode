namespace WebShopCleanCode.MenuStates.MenuTypes;

public class SortWaresMenu : MenuBase
{
    public SortWaresMenu()
    {
        optionList = new List<string>();
        currentMenu = "sort menu";
        optionList.Add("Sort by name, descending");
        optionList.Add("Sort by name, ascending");
        optionList.Add("Sort by price, descending");
        optionList.Add("Sort by price, ascending");
        currentChoice = 1;
    }

    public override void DisplayMenu()
    {
        Console.WriteLine(info);
        PrintOption();
        MenuBar();
        AskChoice();
        DisplayMenu();
    }
    
    public override void bubbleSort(string variable, bool ascending)
    {
        if (variable.Equals("name"))
        {
            int length = productList.products.Count;
            for (int i = 0; i < length - 1; i++)
            {
                bool sorted = true;
                int length2 = length - i;
                for (int j = 0; j < length2 - 1; j++)
                {
                    if (ascending)
                    {
                        if (productList.products[j].Name.CompareTo(productList.products[j + 1].Name) < 0)
                        {
                            Product temp = productList.products[j];
                            productList.products[j] = productList.products[j + 1];
                            productList.products[j + 1] = temp;
                            sorted = false;
                        }
                    }
                    else
                    {
                        if (productList.products[j].Name.CompareTo(productList.products[j + 1].Name) > 0)
                        {
                            Product temp = productList.products[j];
                            productList.products[j] = productList.products[j + 1];
                            productList.products[j + 1] = temp;
                            sorted = false;
                        }
                    }
                }

                if (sorted == true)
                {
                    break;
                }
            }
        }
        else if (variable.Equals("price"))
        {
            int length = productList.products.Count;
            for (int i = 0; i < length - 1; i++)
            {
                bool sorted = true;
                int length2 = length - i;
                for (int j = 0; j < length2 - 1; j++)
                {
                    if (ascending)
                    {
                        if (productList.products[j].Price > productList.products[j + 1].Price)
                        {
                            Product temp = productList.products[j];
                            productList.products[j] = productList.products[j + 1];
                            productList.products[j + 1] = temp;
                            sorted = false;
                        }
                    }
                    else
                    {
                        if (productList.products[j].Price < productList.products[j + 1].Price)
                        {
                            Product temp = productList.products[j];
                            productList.products[j] = productList.products[j + 1];
                            productList.products[j + 1] = temp;
                            sorted = false;
                        }
                    }
                }

                if (sorted == true)
                {
                    break;
                }
            }
        }
    }
    
    public override void WareSortedNotification()
    {
        Console.WriteLine();
        Console.WriteLine("Wares sorted.");
        Console.WriteLine();
    }
}