using Spectre.Console;

namespace NeuzCli
{
    public partial class Features
    {
        public static void ShowSystemInfo()
        {
            string YesOrNo(bool exp)
            {
                return exp ? "[green]YES[/]" : "[red]NO[/]";
            }

            var grid = new Grid()
                       .AddColumn(new GridColumn().PadRight(4))
                       .AddColumn(new GridColumn())
                       .AddRow()
                       .AddRow("[darkorange3]操作系统版本[/]", $"{Environment.OSVersion}")
                       .AddRow("[darkorange3]机器名[/]", $"{Environment.MachineName}")
                       .AddRow("[darkorange3]用户名[/]", $"{Environment.UserName}")
                       .AddRow("[darkorange3]CPU 核心数[/]", $"{Environment.ProcessorCount}")
                       .AddRow("[darkorange3]64位系统[/]", $"{YesOrNo(Environment.Is64BitOperatingSystem)}")
                       .AddRow();

            AnsiConsole.Write(new Panel(grid).Header("系统信息"));
        }
    }
}