using NeuzCli.ConsoleApp.Models;

namespace NeuzCli.ConsoleApp
{
    internal partial class Menus
    {
        public static MenuCls RuntimeCheck = new()
        {
            Name        = "RuntimeCheck",
            Description = "系统运行环境检测",
            Action      = _ => Features.ShowSystemInfo()
        };
    }
}