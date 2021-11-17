using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;

namespace NeuzCli.CliApp.Commands.Source
{
    internal class SourceResetCommand : Command<SourceResetCommand.Settings>
    {
        internal static string Description = "源管理 - 还原";

        internal class Settings : CommandSettings
        {
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            // ConsoleApp.Features.ResetSource();
            return 0;
        }
    }
}