using NeuzCli.Models;
using Spectre.Console;

namespace NeuzCli;

/// <summary>
/// 帮助类
/// </summary>
public partial class Utils
{
    public static IEnumerable<MenuCls> GetMenus()
    {
        return new List<MenuCls>()
        {
            new()
            {
                Name        = "SystemInfo",
                Description = "显示操作系统信息",
                Action = ctx =>
                {
                    PrintSystemInfo().Wait();
                },
            },

            new()
            {
                Name        = "Test",
                Description = "测试",
                Action = ctx =>
                {
                },
                SubMenus = new List<MenuCls>
                {
                    new()
                    {
                        Name        = "SystemInfo-S1",
                        Description = "SystemInfo-S1",
                        Action = ctx =>
                        {
                            AnsiConsole.WriteLine($"--SystemInfo-S1");
                        },
                    },
                    new()
                    {
                        Name        = "SystemInfo-S2",
                        Description = "SystemInfo-S2",
                        Action = ctx =>
                        {
                            AnsiConsole.WriteLine($"--SystemInfo-S2");
                        },
                        SubMenus = new List<MenuCls>
                        {
                            new()
                            {
                                Name        = "SystemInfo-S2-1",
                                Description = "SystemInfo-S2-1",
                                Action = ctx =>
                                {
                                    AnsiConsole.WriteLine($"--SystemInfo-S2-1");
                                },
                            },
                            new MenuCls
                            {
                                Name        = "SystemInfo-S2-2",
                                Description = "SystemInfo-S2-2",
                                Action = ctx =>
                                {
                                    AnsiConsole.WriteLine($"--SystemInfo-S2-2");
                                },
                            },
                        }
                    }
                },
            },
            new()
            {
                Name        = "Exit",
                Description = "退出",
                Action      = ctx => Environment.Exit(0)
            },
        };
    }
}