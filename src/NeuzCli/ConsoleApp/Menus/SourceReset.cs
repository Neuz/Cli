using NeuzCli.ConsoleApp.Models;
using Spectre.Console;

namespace NeuzCli.ConsoleApp
{
    internal partial class Menus
    {
        public static MenuCls SourceReset = new()
        {
            Name        = "ResetSource",
            Description = "源管理 - 还原",
            Action      = _ =>
            {
                Features.ResetSource();
            }
        };
    }
}