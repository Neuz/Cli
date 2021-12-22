#nullable enable
using Neuz.DevKit.Extensions;
using NeuzCli.Models;
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

    public static string SucStr(string? str)
    {
        return $"[green]{str ?? string.Empty}[/]";
    }

    public static string ErrorStr(string? str)
    {
        return $"[red]{str ?? string.Empty}[/]";
    }

    public static string WarnStr(string? str)
    {
        return $"[yellow]{str ?? string.Empty}[/]";
    }

    public static MultiSelectionPrompt<IndexCls.PackageCls> BuildMultiSelection(IEnumerable<IndexCls.PackageCls> packages)
    {
        var multiSelectionPrompt = new MultiSelectionPrompt<IndexCls.PackageCls>()
        {
            Title            = "请选择",
            PageSize         = 30,
            MoreChoicesText  = "",
            InstructionsText = "[grey]按[blue]<空格键>[/]选择   [green]<回车键>[/]确认[/]",
            Converter        = cls => cls.Name ?? "",
            Required         = false
        };


        var root = multiSelectionPrompt.AddChoice(new IndexCls.PackageCls { Name = "全部" });


        packages.GroupBy(p => p.PackageType)
                .Select(g => new
                {
                    title = new IndexCls.PackageCls { Name = Enum.GetName(g.Key) },
                    items = g.ToList()
                })
                .ForEach(x =>
                {
                    var a = root.AddChild(x.title);
                    x.items.ForEach(i => a.AddChild(i));
                });


        return multiSelectionPrompt;
    }
}