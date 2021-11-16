using NeuzCli.ConsoleApp.Models;

namespace NeuzCli.ConsoleApp
{
    internal partial class Menus
    {
        public static MenuCls AppAdd = new()
        {
            Name        = "AppAdd",
            Description = "应用管理 - 安装指定的应用程序",
            Action      = _ => throw new NotImplementedException()
        };
    }
}