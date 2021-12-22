namespace NeuzCli.ConsoleApp;

public partial class Menus
{
    public static MenuCls ServiceManagerMenu = new()
    {
        Name        = "Service.Manager",
        Description = "服务管理",
        Action      = ServiceManager.Run
    };

    private static class ServiceManager
    {
        public static void Run()
        {
        }
    }
}