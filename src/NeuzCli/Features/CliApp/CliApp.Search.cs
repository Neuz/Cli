#nullable enable
using Neuz.DevKit.Extensions;
using Spectre.Console;

namespace NeuzCli;

public partial class Features
{
    public partial class CliApp
    {
        public static void Search(string appName)
        {
            var index = AnsiConsole.Status()
                                   .AutoRefresh(true)
                                   .Spinner(Spinner.Known.SimpleDotsScrolling)
                                   .Start("正在查找...", async ctx => await Utils.QueryIndex(Global.Config.Source)).Result;

            if (!index.Packages.Any()) return;
            var grid = new Grid()
                       .AddColumn(new GridColumn().PadRight(4))
                       .AddColumn(new GridColumn())
                       .AddRow();

            var result = !appName.IsNullOrEmpty()
                ? index.Packages.Where(p => p.Id.Contains(appName) || p.Name.Contains(appName))
                : index.Packages;

            result.ForEach(p => grid.AddRow(p.Id, p.Name));

            grid.AddRow();
            AnsiConsole.Write(grid);
        }
    }
        
}