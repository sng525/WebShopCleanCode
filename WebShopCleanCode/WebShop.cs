using WebShopCleanCode.LeftRightOkBackCommand;
using WebShopCleanCode.MenuStates;

namespace WebShopCleanCode
{
    public class WebShop
    {
        public void Run()
        {
            var menuState = new MenuContext();
            menuState.SetState(new MainMenu());

            Console.WriteLine("Welcome to the WebShop!");
            
            const bool running = true;
            
            while (running)
            {
                menuState.Request();
            }
        }
    }
}