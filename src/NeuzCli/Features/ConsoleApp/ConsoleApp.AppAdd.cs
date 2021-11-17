#nullable enable
using Spectre.Console;

namespace NeuzCli;

public partial class Features
{
    public partial class ConsoleApp
    {
        public static void AppAdd()
        {
            // todo

            AnsiConsole.WriteLine("todo");

            //     var index = AnsiConsole.Status()
            //                            .AutoRefresh(true)
            //                            .Spinner(Spinner.Known.SimpleDotsScrolling)
            //                            .Start("正在查找...", async ctx => await Utils.QueryIndex(Global.Config.Source)).Result;
            //
            //     if (!index.Packages.Any())
            //     {
            //         AnsiConsole.Markup("没有可用的应用程序");
            //         return;
            //     }
            //
            //     var packages = AnsiConsole.Prompt(
            //         new MultiSelectionPrompt<string>()
            //             .Title("选择所需应用程序")
            //             .Required()
            //             .InstructionsText(
            //                 "[grey](Press [blue]<space>[/] to toggle a fruit, [green]<enter>[/] to accept)[/]")
            //             .AddChoiceGroup("常用服务", new[]
            //             {
            //                 "MySQL", "Redis"
            //             })
            //             .AddChoiceGroup("管理工具", new[]
            //             {
            //                 "Nevicat", "SSMS"
            //             }));
        }
    }
}