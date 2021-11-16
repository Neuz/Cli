using NeuzCli.CliApp;
using NeuzCli.ConsoleApp;

args = new[] { "app", "search" };
// 启动
if (args.Length > 0)
    new CliApp().Run(args);
else
    new ConsoleApp().Run();