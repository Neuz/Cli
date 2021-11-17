namespace NeuzCli.ConsoleApp;

public partial class Menus
{
    public static MenuCls Exit = new()
    {
        Name        = "Exit",
        Description = "退出",
        Action      = _ => Environment.Exit(0)
    };
}