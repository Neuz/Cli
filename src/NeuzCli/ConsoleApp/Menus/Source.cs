using NeuzCli.Models;
using Spectre.Console;

namespace NeuzCli.ConsoleApp;

public partial class Menus
{
    public static MenuCls Source = new()
    {
        Name        = "Source",
        Description = "源管理",
        Action = () =>
        {
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine($"{Utils.WarnStr("当前源")}: {Utils.LinkStr(Global.CliAppConfig!.Source)}");
            AnsiConsole.WriteLine();
        },
        SubMenus = new[]
        {
            SourceMenu.Set,
            SourceMenu.Reset,
            SourceMenu.Update,
        }
    };
}

public partial class SourceMenu
{
    public static MenuCls Set = new()
    {
        Name        = "Source.Set",
        Description = "设置",
        Action      = SetAction
    };

    public static MenuCls Reset = new()
    {
        Name        = "Source.Reset",
        Description = "还原",
        Action      = ResetAction
    };

    public static MenuCls Update = new()
    {
        Name        = "Source.Update",
        Description = "更新",
        Action      = UpdateAction
    };
}

public partial class SourceMenu
{
    private static void SetConfig(string url)
    {
        Global.CliAppConfig!.Source = url;
        Utils.WriteFileAsync(Global.CliAppConfig, Global.CliAppConfigFile!).Wait();
    }

    private static void SetAction()
    {
        var url = AnsiConsole.Ask<string>("输入新的源: ");
        if (!AnsiConsole.Confirm("确认修改?")) return;
        SetConfig(url);
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"{Utils.SucStr("源设置完成")} -> {Utils.LinkStr(url)}");
        AnsiConsole.WriteLine();
    }

    private static void ResetAction()
    {
        var defaultSource = new AppConfigCls().Source;
        if (!AnsiConsole.Confirm("是否还原?")) return;
        SetConfig(defaultSource);
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"{Utils.SucStr("还原完成")} -> {Utils.LinkStr(defaultSource)}");
        AnsiConsole.WriteLine();
    }

    private static void UpdateAction()
    {
        AnsiConsole.Status()
                   .Spinner(Spinner.Known.SimpleDotsScrolling)
                   .AutoRefresh(true)
                   .StartAsync("更新源", async ctx =>
                   {
                       try
                       {
                           AnsiConsole.MarkupLine($"[grey][[INFO]][/] Fetch -> {Global.CliAppConfig!.Source}");
                           var remoteIndex = await Utils.GetIndexJson(Global.CliAppConfig.Source);
                           if (remoteIndex == null) throw new ArgumentNullException($"源数据获取失败");
                           await Utils.WriteFileAsync(remoteIndex, Global.LocalIndexFile!);
                       }
                       catch (Exception ex)
                       {
                           AnsiConsole.WriteException(ex);
                       }

                       ConsoleApp.Initialization().Wait();
                   }).Wait();

        AnsiConsole.WriteLine();

        AnsiConsole.MarkupLine($"{Utils.SucStr("更新完成")}");
        AnsiConsole.WriteLine();
    }
}