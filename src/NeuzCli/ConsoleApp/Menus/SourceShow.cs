using NeuzCli.ConsoleApp.Models;

namespace NeuzCli.ConsoleApp
{
    internal partial class Menus
    {
        public static MenuCls SourceShow = new()
        {
            Name        = "SourceShow",
            Description = "源管理 - 查看",
            Action      = _ => Features.ShowCurrentSource()
        };
    }
}