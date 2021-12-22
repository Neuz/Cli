using NeuzCli.Models;
using Spectre.Console;

namespace NeuzCli;

/// <summary>
/// 帮助类
/// </summary>
public partial class Utils
{
    public static async Task PackageInstaller(IEnumerable<IndexCls.PackageCls> packages)
    {
        await AnsiConsole.Status()
                         .StartAsync("安装中...", async ctx =>
                         {
                             foreach (var package in packages)
                             {
                                 ctx.Status(package.Name!);
                                 if (package.Installer == null) continue;

                                 switch (package.Installer.ExecuteType)
                                 {
                                     case IndexCls.PackageCls.ExecuteTypeEnum.Exe:
                                         await ExeInstaller(package);
                                         break;
                                     case IndexCls.PackageCls.ExecuteTypeEnum.Script:
                                         await ScriptInstaller(package);
                                         break;
                                     case IndexCls.PackageCls.ExecuteTypeEnum.InsideMySQL:
                                         await MySQLInstaller(package);
                                         break;
                                     case IndexCls.PackageCls.ExecuteTypeEnum.InsideNginx:
                                         break;
                                     default:
                                         throw new ArgumentOutOfRangeException();
                                 }
                             }
                         });
    }

    private static async Task ExeInstaller(IndexCls.PackageCls package)
    {
        var path = Path.Combine(Global.NeuzInstallPath, package.DefaultPath, package.Installer.Path);
        if (!File.Exists(path))
        {
            AnsiConsole.WriteLine($"无法找到路径: {path}");
            return;
        }

        var args = package.Installer?.Args ?? "";

        await ExecuteExe(path, args);
    }

    private static async Task ScriptInstaller(IndexCls.PackageCls package)
    {
        var path = Path.Combine(Global.NeuzInstallPath, package.DefaultPath, package.Installer.Path);
        if (!File.Exists(path))
        {
            AnsiConsole.WriteLine($"无法找到路径: {path}");
            return;
        }

        var args = package.Installer?.Args ?? "";

        await ExecuteBatFile(path, args);
    }

    private static async Task MySQLInstaller(IndexCls.PackageCls package)
    {
        var path = Path.Combine(Global.NeuzInstallPath, package.DefaultPath);
        if (!File.Exists(path))
        {
            AnsiConsole.WriteLine($"无法找到路径: {path}");
            return;
        }

    }
}