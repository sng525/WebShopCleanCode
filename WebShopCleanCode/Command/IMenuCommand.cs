using WebShopCleanCode.Menus;

namespace WebShopCleanCode.Command;

public interface IMenuCommand
{
    void Execute(int currentChoice);
}