using Neuz.DevKit.Extensions;
using NeuzCli.Extensions;
using NeuzCli.Models;
using Spectre.Console;

namespace NeuzCli.ConsoleApp;

public partial class Menus
{
    public static MenuCls RuntimeInstallMenu = new()
    {
        Name        = "Runtime.Install",
        Description = "运行时安装",
        Action      = RuntimeInstall.Run
    };

    private static class RuntimeInstall
    {
        public static void Run()
        {
            var packages = Global.LocalIndex!.Packages
                                 .Where(p => p.PackageType == IndexCls.PackageCls.PackageTypeEnum.Runtime)
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

            Utils.PackageInstaller(selectedList).Wait();

            
            
        }

        private static void CheckRuntime()
        {
            // TODO
            AnsiConsole.WriteLine("环境检查未完成");
        }
    }
}