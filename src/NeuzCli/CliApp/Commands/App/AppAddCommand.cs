using System.ComponentModel;
using System.Text;
using Spectre.Console;
using Spectre.Console.Cli;

namespace NeuzCli.CliApp.Commands.App
{
    public class AppAddCommand : Command<AppAddCommand.Settings>
    {
        public static string Description = "应用管理 - 安装指定的应用程序";

        public sealed class Settings : CommandSettings
        {
            [CommandArgument(0, "<APP_NAME>")]
            [Description("应用程序名称")]
            public string[] AppName { get; set; }
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            var c = string.Join(", ", settings.AppName);
            AnsiConsole.WriteLine($"app Name [{c}]");

            return 0;
        }
    }
}