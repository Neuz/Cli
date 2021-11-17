#nullable enable
using Spectre.Console;

namespace NeuzCli;

/// <summary>
/// 帮助类
/// </summary>
public partial class Utils
{
    public static string LinkStr(string? str)
    {
        var link = str ?? string.Empty;
        return AnsiConsole.Profile.Capabilities.Links
            ? $"[link={link}][blue]{link}[/][/]"
            : $"[blue]{link}[/]";
    }

    public static string SuccessStr(string? str)
    {
        return $"[green]{str ?? string.Empty}[/]";
    }

    public static string FailStr(string? str)
    {
        return $"[red]{str ?? string.Empty}[/]";
    }

    public static string MarkedStr(string? str)
    {
        return $"[yellow]{str ?? string.Empty}[/]";
    }
}