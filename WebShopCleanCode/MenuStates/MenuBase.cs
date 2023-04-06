using WebShopCleanCode.Menus;

namespace WebShopCleanCode;

public abstract class MenuBase : IMenu
{
   public virtual string option1 { get; set; }
   public virtual string option2 { get; set; }
   public virtual string option3 { get; set; }
   public virtual string option4 { get; set; }
   public virtual string currentMenu { get; set; }
   public virtual string info { get; set; }

   public virtual Customer currentCustomer { get; set; }
   public virtual int amountOfOptions { get; set; }
   public virtual int currentChoice { get; set; }
   public virtual ProductList productList { get; set; }

   public virtual void DisplayMenu()
   {
      throw new NotImplementedException();
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
}
