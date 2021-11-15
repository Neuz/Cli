using NeuzCli.Commands;
using NeuzCli.Models;
using Spectre.Console;
using Spectre.Console.Cli;

// args = new[] {"-h" };

// 启动
if (args.Length > 0)
    CliApp();
else
    ConsoleApp();

void CliApp()
{
    var app = new CommandApp();
    app.Configure(conf =>
    {
        conf.Settings.ApplicationName    = "NeuzCli.exe";
        conf.Settings.ApplicationVersion = "v0.1";

        conf.AddCommand<SystemInfoCommand>("SystemInfo")
            .WithAlias("si")
            // .WithExample(new[] { "SystemInfo"})
            // .WithExample(new[] { "si"})
            .WithDescription(SystemInfoCommand.Description);
    });

    app.RunAsync(args);
}

void ConsoleApp()
{
    AnsiConsole.Status()
               .Spinner(Spinner.Known.SimpleDotsScrolling)
               .AutoRefresh(true)
               .Start("正在初始化...", ctx =>
               {
                   Thread.Sleep(2000);
               });

    while (true)
    {
        RunMenu();
        AnsiConsole.Prompt(new TextPrompt<string>("任意键返回主菜单...").AllowEmpty());
        AnsiConsole.Clear();
    }

    void RunMenu(IEnumerable<MenuCls> items = null, Dictionary<string, object> ctx = null)
    {
        items ??= NeuzCli.Utils.GetMenus();
        ctx   ??= new Dictionary<string, object>();
        var selected = AnsiConsole.Prompt(
            new SelectionPrompt<MenuCls>()
                .Title("请选择...")
                .AddChoices(items));
        ctx.Add(selected.Name, selected);
        selected.Action.Invoke(ctx);
        if (selected.SubMenus.Any()) RunMenu(selected.SubMenus, ctx);
    }
}