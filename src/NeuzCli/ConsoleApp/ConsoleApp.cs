using NeuzCli.Models;
using Spectre.Console;

namespace NeuzCli.ConsoleApp
{
    public class ConsoleApp
    {
        private readonly List<MenuCls> _menus = new()
        {
            Menus.RuntimeInstallMenu,
            Menus.ToolManagerMenu,
            Menus.ToolInstallMenu,
            Menus.ServiceManagerMenu,
            Menus.ServiceInstallMenu,
            Menus.Source,
            Menus.Exit
        };

        private static void ShowMenu(IEnumerable<MenuCls> items)
        {
            var selected = AnsiConsole.Prompt(new SelectionPrompt<MenuCls>()
                                              .Title("请选择...")
                                              .AddChoices(items));
            selected.Action.Invoke();
            if (selected.SubMenus.Any()) ShowMenu(selected.SubMenus);
        }


        public int Run()
        {
            AnsiConsole.Clear();
            AnsiConsole.WriteLine("初始化...");
            Initialization().Wait();
            AnsiConsole.WriteLine("初始化完成");
            AnsiConsole.Clear();


            while (true)
            {
                ShowMenu(_menus);
                AnsiConsole.Prompt(new TextPrompt<string>("任意键返回主菜单...").AllowEmpty());
                AnsiConsole.Clear();
            }

            // ReSharper disable once FunctionNeverReturns
        }

        public static async Task Initialization()
        {
            var neuzInstallPath = Utils.ReadRegistry("", "InstallPath");

            if (neuzInstallPath == null)
            {
                var selected = AnsiConsole.Prompt(
                    new SelectionPrompt<DriveInfo>()
                        .Title("请选择安装路径...")
                        .AddChoices(DriveInfo.GetDrives())
                        .UseConverter(drive => Path.Combine(drive.Name, Global.Organization)));
                neuzInstallPath = Utils.WriteRegistry("", "InstallPath", Path.Combine(selected.Name, Global.Organization));
            }

            Global.NeuzInstallPath = neuzInstallPath;

            AnsiConsole.MarkupLine($"[grey][[INFO]][/] NeuzInstallPath ->{Global.NeuzInstallPath}");


            // Cli install Path

            Global.CliInstallPath = Utils.ReadRegistry(Global.AppName, "InstallPath")
                                 ?? Utils.WriteRegistry(Global.AppName, "InstallPath", Path.Combine(Global.NeuzInstallPath!, "NeuzCli"))!;


            // Cli app.config
            Global.CliAppConfigFile = Path.Combine(Global.CliInstallPath, "app.config");
            Global.CliAppConfig = File.Exists(Global.CliAppConfigFile)
                ? await Utils.ReadFileAsync<AppConfigCls>(Global.CliAppConfigFile)
                : await Utils.WriteFileAsync(new AppConfigCls(), Global.CliAppConfigFile);

            AnsiConsole.MarkupLine($"[grey][[INFO]][/] Cli app.config ->{Global.CliAppConfigFile}");

            // Cli index.json
            async Task<IndexCls?> FetchIndex(string url)
            {
                AnsiConsole.MarkupLine($"[grey][[INFO]][/] Fetch -> {url}");
                var remote = await Utils.GetIndexJson(url);
                AnsiConsole.MarkupLine($"[grey][[INFO]][/] Fetch 成功 -> {url}");
                return await Utils.WriteFileAsync(remote, Global.LocalIndexFile!);
            }

            Global.LocalIndexFile = Path.Combine(Global.CliInstallPath, "index.json");
            Global.LocalIndex = File.Exists(Global.LocalIndexFile)
                ? await Utils.ReadFileAsync<IndexCls>(Global.LocalIndexFile)
                : await FetchIndex(Global.CliAppConfig!.Source);
            AnsiConsole.MarkupLine($"[grey][[INFO]][/] Cli index.json ->{Global.LocalIndexFile}");


            // CliTmpPath
            Global.CliTmpPath = Path.Combine(Global.CliInstallPath, "tmp");
            Directory.CreateDirectory(Global.CliTmpPath);
            AnsiConsole.MarkupLine($"[grey][[INFO]][/] CliTmpPath ->{Global.CliTmpPath}");
        }
    }
}