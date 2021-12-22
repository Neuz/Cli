using Microsoft.Win32;
using Neuz.DevKit.Extensions;

namespace NeuzCli;

/// <summary>
/// 帮助类
/// </summary>
public partial class Utils
{
    public static string? ReadRegistry(string subKey, string valueName)
    {
        using var key = subKey.IsNullOrEmpty()
            ? Registry.LocalMachine.CreateSubKey(Global.RegistryBaseKey)
            : Registry.LocalMachine.CreateSubKey(Global.RegistryBaseKey).CreateSubKey(subKey);
        return key.GetValue(valueName)?.ToString();
        
    }

    public static string? WriteRegistry(string subKey, string valueName, string value)
    {
        using var key = subKey.IsNullOrEmpty()
            ? Registry.LocalMachine.CreateSubKey(Global.RegistryBaseKey)
            : Registry.LocalMachine.CreateSubKey(Global.RegistryBaseKey).CreateSubKey(subKey);
        key.SetValue(valueName, value);
        return value;
    }
}