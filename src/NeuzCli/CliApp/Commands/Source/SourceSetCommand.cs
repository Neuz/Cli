using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;

namespace NeuzCli.CliApp.Commands.Source
{
    internal class SourceSetCommand : Command<SourceSetCommand.Settings>
    {
        internal static string Description = "源管理 - 设置";

        internal class Settings : CommandSettings
        {
            [CommandArgument(0, "<SOURCE_URL>")]
            [Description("源地址")]
            public string Url { get; set; }
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            Features.SetSource(settings.Url);
            return 0;
        }
    }
}