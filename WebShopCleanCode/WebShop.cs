﻿using WebShopCleanCode.MenuStates;
using WebShopCleanCode.MenuStates.MenuTypes;

namespace WebShopCleanCode
{
    public class WebShop
    {
        public void Run()
        {
            Console.WriteLine("Welcome to the WebShop!");
            
            var menuState = new MenuContext();
            menuState.SetState(new MainMenu());
            menuState.Request();
        }
    }
}