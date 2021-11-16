using NeuzCli.ConsoleApp.Models;

namespace NeuzCli.ConsoleApp
{
    internal partial class Menus
    {
        public static MenuCls AppList = new()
        {
            Name        = "AppList",
            Description = "应用管理 - 列出已安装的应用程序",
            Action      = _ => throw new NotImplementedException()
        };
    }
}