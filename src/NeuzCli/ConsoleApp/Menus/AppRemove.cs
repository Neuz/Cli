using NeuzCli.ConsoleApp.Models;

namespace NeuzCli.ConsoleApp
{
    internal partial class Menus
    {
        public static MenuCls AppRemove = new()
        {
            Name        = "AppRemove",
            Description = "应用管理 - 卸载指定的应用程序",
            Action      = _ => throw new NotImplementedException()
        };
    }
}