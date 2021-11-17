using NeuzCli.Models;
using Spectre.Console;

namespace NeuzCli.ConsoleApp.Features
{
    public partial class BaseFeature
    {
        public static async Task Initialization()
        {
#pragma warning disable CA1416 // 验证平台兼容性
            Global.ConfigPath = Utils.ReadRegistry(Global.AppName, "ConfigPath") ?? Path.Combine(Global.AppDataPath, "app.config");
            Global.TmpPath    = Utils.ReadRegistry(Global.AppName, "TmpPath") ?? Path.Combine(Global.AppDataPath, "tmp");
            Global.IndexPath  = Utils.ReadRegistry(Global.AppName, "IndexPath") ?? Path.Combine(Global.AppDataPath, "index.json");
            Utils.WriteRegistry(Global.AppName, "ConfigPath", Global.ConfigPath);
            Utils.WriteRegistry(Global.AppName, "TmpPath", Global.TmpPath);
            Utils.WriteRegistry(Global.AppName, "IndexPath", Global.IndexPath);
#pragma warning restore CA1416 // 验证平台兼容性

            // app.config
            if (!File.Exists(Global.ConfigPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Global.ConfigPath)!);
                var defaultConfig = new ConfigCls();
                await Utils.WriteFileAsync(defaultConfig, Global.ConfigPath);
            }

            Global.Config = await Utils.ReadFileAsync<ConfigCls>(Global.ConfigPath)
                         ?? new ConfigCls();

            // index.json
            Directory.CreateDirectory(Path.GetDirectoryName(Global.IndexPath)!);
            if (File.Exists(Global.IndexPath))
            {
                Global.Index = await Utils.ReadFileAsync<IndexCls>(Global.IndexPath);
            }
        }
        
    }
}