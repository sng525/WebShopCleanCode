namespace WebShopCleanCode.MenuStates.MenuTypes;

public class SortWaresMenu : MenuBase
{
    public SortWaresMenu()
    {
        optionList = new List<string>();
        productList = new ProductList();
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

    public override void QuickSortByName(List<Product> products, int start, int end, bool ascending)
    {
        if (start <= end)
        {
            int pivotIndex = PartitionByName(products, start, end, ascending);
            QuickSortByName(products, start, pivotIndex - 1, ascending);
            QuickSortByName(products, pivotIndex + 1, end, ascending);
        }
    }
    
    public override void QuickSortByPrice(List<Product> products, int start, int end, bool ascending)
    {
        if (start <= end)
        {
            int pivotIndex = PartitionByPrice(products, start, end, ascending);
            QuickSortByPrice(products, start, pivotIndex - 1, ascending);
            QuickSortByPrice(products, pivotIndex + 1, end, ascending);
        }
    }
    
    public int PartitionByName(List<Product> products, int start, int end, bool ascending)
    {
        var pivotProduct = products[end];
        int pivotIndex = start;

        for (int i = start; i < end; i++)
        {
            if (ascending)
            {
                if (products[i].Name.CompareTo(pivotProduct.Name) < 0)
                {
                    Swap(products, i, pivotIndex);
                    pivotIndex++;
                }
            }
            else
            {
                if (products[i].Name.CompareTo(pivotProduct.Name) > 0)
                {
                    Swap(products, i, pivotIndex);
                    pivotIndex++;
                }
            }
        }

        Swap(products, pivotIndex, end);
        return pivotIndex;
    }
    
    public int PartitionByPrice(List<Product> products, int start, int end, bool ascending)
    {
        var pivotProduct = products[end];
        int pivotIndex = start;

        for (int i = start; i < end; i++)
        {
            if (ascending)
            {
                if (products[i].Price < pivotProduct.Price)
                {
                    Swap(products, i, pivotIndex);
                    pivotIndex++;
                }
            }
            else
            {
                if (products[i].Price > pivotProduct.Price)
                {
                    Swap(products, i, pivotIndex);
                    pivotIndex++;
                }
            }
        }

        Swap(products, pivotIndex, end);
        return pivotIndex;
    }

    private void Swap(List<Product> products, int a, int b)
    {
        (products[a], products[b]) = (products[b], products[a]);
    }

    public override void WareSortedNotification()
    {
        Console.WriteLine();
        Console.WriteLine("Wares sorted.");
        Console.WriteLine();
    }
}