using Neuz.DevKit.Extensions;
using NeuzCli.Extensions;
using NeuzCli.Models;
using Spectre.Console;

namespace NeuzCli.ConsoleApp;

public partial class Menus
{
    public static MenuCls ToolInstallMenu = new()
    {
        Name        = "Tool.Install",
        Description = "软件安装",
        Action      = ToolInstall.Run
    };

    private static class ToolInstall
    {
        public static void Run()
        {
            var packages = Global.LocalIndex!.Packages
                                 .Where(p => p.PackageType == IndexCls.PackageCls.PackageTypeEnum.Tool)
                                 .Where(p => !p.IsDownloaded())
                                 .Where(p => !p.Url.IsNullOrEmpty())
                                 .ToList();

            if (!packages.Any())
            {
                AnsiConsole.WriteLine("找不到可用的选项");
                return;
            }

            var selectedList = Utils.BuildMultiSelection(packages).Show(AnsiConsole.Console);

            if (!selectedList.Any())
            {
                AnsiConsole.WriteLine("选择需要安装的软件");
                return;
            }

            var downloadTasks = selectedList
                                .Select(p =>
                                {
                                    ArgumentNullException.ThrowIfNull(p.DefaultPath);

                                    var fileName      = Path.GetFileName(p.Url)!;
                                    var localFileName = Path.Combine(Global.CliTmpPath!, fileName);
                                    var unZipPath     = Path.Combine(Global.NeuzInstallPath!, p.DefaultPath);
                                    return new Utils.DownloadTask
                                    {
                                        Url           = p.Url,
                                        LocalFileName = localFileName,
                                        Description   = fileName,
                                        UnZipPath     = unZipPath
                                    };
                                })
                                .ToArray();
            Utils.Downloader.StartAsync(downloadTasks).Wait();
        }
    }
}