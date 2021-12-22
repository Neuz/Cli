using NeuzCli.Models;

namespace NeuzCli.Extensions
{
    public static class PackageClsExt
    {
        /// <summary>
        /// 是否已下载
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        public static bool IsDownloaded(this IndexCls.PackageCls package)
        {
            return File.Exists(package.GetAppNeuzFilePath());
        }

        public static string GetAppNeuzFilePath(this IndexCls.PackageCls package)
        {
            ArgumentNullException.ThrowIfNull(Global.NeuzInstallPath);
            ArgumentNullException.ThrowIfNull(package.DefaultPath);
            return Path.Combine(Global.NeuzInstallPath, package.DefaultPath, Global.AppNeuzFileName);
        }
    }
}