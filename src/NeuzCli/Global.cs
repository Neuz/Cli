using NeuzCli.Models;

namespace NeuzCli
{
    public static class Global
    {
        /// <summary>
        /// 组织名
        /// </summary>
        public static string Organization = "Neuz";

        /// <summary>
        /// 应用名
        /// </summary>
        public static string AppName = "NeuzCli";

        public static string AppNeuzFileName = "app.neuz";

        /// <summary>
        /// 注册表BaseKey
        /// </summary>
        public static string RegistryBaseKey => $"SOFTWARE\\{Organization}";

        public static string CliInstallPath { get; set; }

        public static string? NeuzInstallPath { get; set; }

        public static string? CliTmpPath { get; set; }

        public static string? CliAppConfigFile { get; set; }

        public static AppConfigCls? CliAppConfig { get; set; }

        public static string? LocalIndexFile { get; set; }

        public static IndexCls? LocalIndex { get; set; }
    }
}