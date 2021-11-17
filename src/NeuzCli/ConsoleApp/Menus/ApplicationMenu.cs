using Spectre.Console;

namespace NeuzCli.ConsoleApp;

public partial class Menus
{
    public static MenuCls Application = new()
    {
        Name        = "Application",
        Description = "应用管理",
        SubMenus = new[]
        {
            ApplicationMenu.Runtime,
            ApplicationMenu.Service,
            ApplicationMenu.Tool
        }
    };
}

public class ApplicationMenu
{
    public static MenuCls Runtime = new()
    {
        Name        = "Application.Runtime",
        Description = "系统环境",
        Action      = _ => AnsiConsole.WriteLine("未实现")
    };

    public static MenuCls Service = new()
    {
        Name        = "Application.Service",
        Description = "服务",
        Action      = _ => AnsiConsole.WriteLine("未实现")
    };

    public static MenuCls Tool = new()
    {
        Name        = "Application.Tool",
        Description = "工具",
        Action      = _ => AnsiConsole.WriteLine("未实现")
    };
}