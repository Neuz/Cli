using NeuzCli.ConsoleApp.Models;
using Spectre.Console;

namespace NeuzCli.ConsoleApp
{
    internal partial class Menus
    {
        public static MenuCls SourceSet = new()
        {
            Name        = "SourceSet",
            Description = "源管理 - 设置",
            Action = _ =>
            {
                var rule = new Rule()
                {
                    Title     = "源管理 - 设置",
                    Alignment = Justify.Left
                };
                AnsiConsole.Write(rule);
                AnsiConsole.WriteLine();
                var url = AnsiConsole.Ask<string>("输入新的源:");
                Features.SetSource(url);
            }
        };
    }
}