using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;

namespace NeuzCli.CliApp.Commands
{
    public class SystemInfoCommand : Command<SystemInfoCommand.Settings>
    {
        public static string Description = "系统运行环境检测";

        public class Settings : CommandSettings
        {
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            Features.ShowSystemInfo();
            return 0;
        }
    }
}