#nullable enable
using System.Runtime.Versioning;
using Microsoft.Win32;

namespace NeuzCli;

/// <summary>
/// 帮助类
/// </summary>
public partial class Utils
{
    [SupportedOSPlatform("windows")]
    public static string? ReadRegistry(string subKey, string valueName)
    {
        using var key = Registry.LocalMachine.CreateSubKey(Global.RegistryBaseKey).CreateSubKey(subKey);
        return key.GetValue(valueName)?.ToString();
    }

    [SupportedOSPlatform("windows")]
    public static void WriteRegistry(string subKey, string valueName, object value)
    {
        using var key = Registry.LocalMachine.CreateSubKey(Global.RegistryBaseKey).CreateSubKey(subKey);
        key.SetValue(valueName, value);
    }
}