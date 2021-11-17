using Spectre.Console;

namespace NeuzCli.ConsoleApp;

public partial class Menus
{
    public static MenuCls System = new()
    {
        Name        = "System",
        Description = "系统功能",
        SubMenus = new[]
        {
            SystemMenu.RuntimeCheck,
            SystemMenu.PortCheck
        }
    };
}

public class SystemMenu
{
    public static MenuCls RuntimeCheck = new()
    {
        Name        = "System.RuntimeCheck",
        Description = "系统运行环境检测",
        Action      = _ => AnsiConsole.WriteLine("未实现")
    };

    public static MenuCls PortCheck = new()
    {
        Name        = "System.PortCheck",
        Description = "端口检测",
        Action      = _ => AnsiConsole.WriteLine("未实现")
    };
}