#nullable enable
using System.Text.Json;
using NeuzCli.Models;

namespace NeuzCli;

/// <summary>
/// 帮助类
/// </summary>
public partial class Utils
{
    public static void SaveConfig(ConfigCls config) => File.WriteAllText(Global.ConfigPath, JsonSerializer.Serialize(config));

    public static ConfigCls? ReadConfig(string configPath) => JsonSerializer.Deserialize<ConfigCls>(File.ReadAllText(configPath));
}