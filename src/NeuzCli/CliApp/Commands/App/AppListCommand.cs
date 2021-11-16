using Spectre.Console;
using Spectre.Console.Cli;

namespace NeuzCli.CliApp.Commands.App
{
    public class AppListCommand : Command<AppListCommand.Settings>
    {
        public static string Description = "应用管理 - 列出已安装的应用程序";

        public sealed class Settings : CommandSettings
        {
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            return 0;
        }
    }
}