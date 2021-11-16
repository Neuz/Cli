#nullable enable
using System.Text.Json;
using System.Text.Json.Nodes;
using Flurl.Http;
using NeuzCli.Models;
using Spectre.Console;

namespace NeuzCli
{
    public partial class Features
    {

        public static void CliAppSearch(string appName)
        {
            var packages = GetAllPackages().Result;

            var grid = new Grid()
                       .AddColumn(new GridColumn().PadRight(4))
                       .AddColumn(new GridColumn())
                       .AddRow();

            packages.ForEach(p => grid.AddRow(p.Id, p.Name));

            grid.AddRow();

            AnsiConsole.Write(new Panel(grid).Header("系统信息"));
        }


        private static Task<List<PackageCls>?> GetAllPackages()
        {
            return AnsiConsole.Status()
                       .Spinner(Spinner.Known.SimpleDotsScrolling)
                       .StartAsync("正在查找", async ctx =>
                       {
                           var indexString  = await Global.Config.Source.GetStringAsync();
                           var indexJsonObj = JsonSerializer.Deserialize<JsonObject>(indexString);
                           return JsonSerializer.Deserialize<List<PackageCls>>(indexJsonObj["packages"]);
                       });
        }
    }
}