using NeuzCli.Models;
using Spectre.Console;

namespace NeuzCli.ConsoleApp.Features
{
    public partial class SourceFeature
    {
        public static void ShowSourceInfo()
        {
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine($"{Utils.MarkedStr("当前源")}: {Utils.LinkStr(Global.Config!.Source)}");
            AnsiConsole.WriteLine();
        }

        public static void SetSource()
        {
            var url = AnsiConsole.Ask<string>("输入新的源: ");
            if (!AnsiConsole.Confirm("确认修改?")) return;
            SetConfig(url);
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine($"{Utils.SuccessStr("源设置完成")} -> {Utils.LinkStr(url)}");
            AnsiConsole.WriteLine();
        }

        public static void ResetSource()
        {
            var defaultSource = new ConfigCls().Source;
            if (!AnsiConsole.Confirm("是否还原?")) return;
            SetConfig(defaultSource);
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine($"{Utils.SuccessStr("还原完成")} -> {Utils.LinkStr(defaultSource)}");
            AnsiConsole.WriteLine();
        }


        public static void UpdateSource()
        {
            // todo
            // AnsiConsole.Status()
            //            .Spinner(Spinner.Known.SimpleDotsScrolling)
            //            .AutoRefresh(true)
            //            .StartAsync("初始化", async ctx =>
            //            {
            //                try
            //                {
            //                    var index = await Utils.GetIndexJson(Global.Config!.Source);
            //                    await Utils.WriteFileAsync(index, Global.IndexPath);
            //                    return true;
            //                }
            //                catch (Exception e)
            //                {
            //                    AnsiConsole.MarkupLine("源更新失败");
            //                    AnsiConsole.WriteException(e);
            //                    return false;
            //                }
            //            }).Wait();
        }

        private static void SetConfig(string url)
        {
            Global.Config!.Source = url;
            Utils.WriteFileAsync(Global.Config, Global.ConfigPath).Wait();
        }
    }
}