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

        /// <summary>
        /// 注册表BaseKey
        /// </summary>
        public static string RegistryBaseKey => $"SOFTWARE\\{Organization}";

        /// <summary>
        /// AppData路径
        /// </summary>
        public static string AppDataPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), Organization, AppName);

        /// <summary>
        /// Neuz Cli 临时文件路径
        /// </summary>
        public static string TmpPath { get; set; }

        /// <summary>
        /// Neuz Cli 配置文件路径
        /// </summary>
        public static string ConfigPath { get; set; }

        /// <summary>
        /// 配置
        /// </summary>
        public static ConfigCls Config { get; set; }
    }
}