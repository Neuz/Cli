using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;

namespace NeuzCli.CliApp.Commands.Source
{
    internal class SourceShowCommand : Command<SourceShowCommand.Settings>
    {
        internal static string Description = "源管理 - 查看";

        internal class Settings : CommandSettings
        {
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            Features.ShowCurrentSource();
            return 0;
        }
    }
}