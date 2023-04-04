using WebShopCleanCode.Menus;

namespace WebShopCleanCode;

public abstract class MenuBase
{
   public virtual string option1 { get; set; }
   public virtual string option2 { get; set; }
   public virtual string option3 { get; set; }
   public virtual string option4 { get; set; }
   public virtual string currentMenu { get; set; }
   // public virtual int amountOfOptions { get; set; }
   public virtual string info { get; set; }
   // public Customer currentCustomer { get; set; }
   // public ProductList productList { get; }

   public virtual void DisplayMenu(Customer currentCustomer, ref int amountOfOptions)
   {
      throw new NotImplementedException();
   }
}
