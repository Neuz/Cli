using NeuzCli.Models;

namespace NeuzCli
{
    public partial class Features
    {
        public static void Initialization()
        {
#pragma warning disable CA1416 // 验证平台兼容性
            Global.ConfigPath = Utils.ReadRegistry(Global.AppName, "ConfigPath") ?? Path.Combine(Global.AppDataPath, "app.config");
            Global.TmpPath    = Utils.ReadRegistry(Global.AppName, "TmpPath") ?? Path.Combine(Global.AppDataPath, "tmp");
            Utils.WriteRegistry(Global.AppName, "ConfigPath", Global.ConfigPath);
            Utils.WriteRegistry(Global.AppName, "TmpPath", Global.TmpPath);
#pragma warning restore CA1416 // 验证平台兼容性

            // Neuz Cli 配置文件写入
            if (!File.Exists(Global.ConfigPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Global.ConfigPath)!);
                var defaultConfig = new ConfigCls();
                Utils.SaveConfig(defaultConfig);
            }

            Global.Config = Utils.ReadConfig(Global.ConfigPath) ?? new ConfigCls();
        }
    }
}