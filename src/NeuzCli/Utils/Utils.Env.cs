using Spectre.Console;

namespace NeuzCli;

/// <summary>
/// 帮助类
/// </summary>
public partial class Utils
{
    public static Task PrintSystemInfo()
    {
        string YesOrNo(bool exp) => exp ? "YES" : "NO";

        var grid = new Grid()
                   .AddColumn(new GridColumn().PadRight(4))
                   .AddColumn(new GridColumn())
                   .AddRow("操作系统版本", $"{Environment.OSVersion}")
                   .AddRow("机器名", $"{Environment.MachineName}")
                   .AddRow("用户名", $"{Environment.UserName}")
                   .AddRow("CPU 核心数", $"{Environment.ProcessorCount}")
                   .AddRow("64位系统", $"{YesOrNo(Environment.Is64BitOperatingSystem)}")
            ;

        AnsiConsole.Write(new Panel(grid).Header("系统信息"));

        return Task.CompletedTask;
    }
}