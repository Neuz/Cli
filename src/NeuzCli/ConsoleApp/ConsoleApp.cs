using NeuzCli.ConsoleApp.Models;
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
                       .Start("初始化", ctx =>
                       {
                           Features.Initialization();
                           SetMenus();
                           Thread.Sleep(2000);
                       });

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
            _menus.Add(Menus.RuntimeCheck);
            _menus.Add(Menus.AppAdd);
            _menus.Add(Menus.AppRemove);
            _menus.Add(Menus.AppList);
            _menus.Add(Menus.SourceShow);
            _menus.Add(Menus.SourceSet);
            _menus.Add(Menus.SourceReset);
            _menus.Add(Menus.ExitMenu);
        }
    }
}