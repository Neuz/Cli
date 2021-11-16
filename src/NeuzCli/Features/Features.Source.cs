using NeuzCli.Models;
using Spectre.Console;

namespace NeuzCli
{
    public partial class Features
    {
        private static string ToLinkString(string link)
        {
            return AnsiConsole.Profile.Capabilities.Links
                ? $"[link={link}][blue]{link}[/][/]"
                : $"[blue]{link}[/]";
        }

        /// <summary>
        /// 展示现有源信息
        /// </summary>
        public static void ShowCurrentSource()
        {
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine($"当前源: {ToLinkString(Global.Config.Source)}");
            AnsiConsole.WriteLine();
        }

        /// <summary>
        /// 设置新的源
        /// </summary>
        /// <param name="source"></param>
        public static void SetSource(string source)
        {
            Global.Config.Source = source;
            Utils.SaveConfig(Global.Config);
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine($"[green]设置完成[/] -> {ToLinkString(source)}");
            AnsiConsole.WriteLine();
        }

        /// <summary>
        /// 还原
        /// </summary>
        public static void ResetSource()
        {
            var defaultSource = new ConfigCls().Source;
            Global.Config.Source = defaultSource;
            Utils.SaveConfig(Global.Config);
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine($"[green]还原完成[/] -> {ToLinkString(defaultSource)}");
            AnsiConsole.WriteLine();
        }
    }
}