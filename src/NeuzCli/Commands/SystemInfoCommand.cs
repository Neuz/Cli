using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;

namespace NeuzCli.Commands
{
    internal class SystemInfoCommand : Command<SystemInfoCommand.Settings>
    {
        internal static string Description = "显示操作系统信息";

        internal class Settings : CommandSettings
        {
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            Utils.PrintSystemInfo();
            return 0;
        }
    }
}