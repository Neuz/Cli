using NeuzCli.ConsoleApp.Features;
using Spectre.Console;

namespace NeuzCli.ConsoleApp
{
    public class ConsoleApp
    {
        private readonly List<MenuCls> _menus = new();

        private void ShowMenu(IEnumerable<MenuCls> items = null, Dictionary<string, object> ctx = null)
        {
            items ??= _menus;
            ctx   ??= new Dictionary<string, object>();
            var selected = AnsiConsole.Prompt(
                new SelectionPrompt<MenuCls>()
                    .Title("请选择...")
                    .AddChoices(items));
            ctx.Add(selected.Name, selected);
            selected.Action.Invoke(ctx);
            if (selected.SubMenus.Any()) ShowMenu(selected.SubMenus, ctx);
        }


        public int Run()
        {
            AnsiConsole.Clear();
            AnsiConsole.Status()
                       .Spinner(Spinner.Known.SimpleDotsScrolling)
                       .AutoRefresh(true)
                       .StartAsync("初始化", async ctx =>
                       {
                           await BaseFeature.Initialization();
                           SetMenus();
                       }).Wait();

            while (true)
            {
                ShowMenu();
                AnsiConsole.Prompt(new TextPrompt<string>("任意键返回主菜单...").AllowEmpty());
                AnsiConsole.Clear();
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private void SetMenus()
        {
            _menus.Add(Menus.System);
            _menus.Add(Menus.Application);
            _menus.Add(Menus.SourceMenu);
            _menus.Add(Menus.Exit);
        }
    }
}