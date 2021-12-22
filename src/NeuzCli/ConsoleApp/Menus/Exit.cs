namespace NeuzCli.ConsoleApp;

public partial class Menus
{
    public static MenuCls Exit = new()
    {
        Name        = "Exit",
        Description = "退出",
        Action      = () => Environment.Exit(0)
    };
}