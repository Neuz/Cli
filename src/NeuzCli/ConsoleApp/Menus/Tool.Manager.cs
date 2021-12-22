using Neuz.DevKit.Extensions;
using NeuzCli.Extensions;
using NeuzCli.Models;
using Spectre.Console;

namespace NeuzCli.ConsoleApp;

public partial class Menus
{
    public static MenuCls ToolManagerMenu = new()
    {
        Name        = "Tool.Manager",
        Description = "软件管理",
        Action      = AppManager.Run
    };

    private static class AppManager
    {
        public static void Run()
        {
            // var packages = Global.LocalIndex!.Packages
            //                      .Where(p => p.IsDownloaded())
            //                      .Where(p => p.PackageType != IndexCls.PackageCls.PackageTypeEnum.Service)
            //                      .ToList();
            //
            // var package = AnsiConsole.Prompt(new SelectionPrompt<IndexCls.PackageCls>()
            //                                  .Title("请选择...")
            //                                  .UseConverter(p => p.Name ?? string.Empty)
            //                                  .AddChoices(packages));
            //
            // var command = AnsiConsole.Prompt(new SelectionPrompt<string>()
            //                                  .Title("请选择...")
            //                                  .AddChoices("运行", "卸载"));
            //
            // if (command.CaseCmp("运行"))
            // {
            //     var appNeuz = package.GetAppNeuz().Result;
            //     if (appNeuz == null) throw new ArgumentException("找不到运行文件");
            //    
            //     appNeuz.
            //     Utils.ExecuteExe()
            // }
        }
    }
}