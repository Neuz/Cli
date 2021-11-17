#nullable enable
using System.Text.Json;

namespace NeuzCli;

/// <summary>
/// 帮助类
/// </summary>
public partial class Utils
{
    public static async Task WriteFileAsync<T>(T obj, string filePath) where T : class, new() => await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(obj));

    public static async Task<T?> ReadFileAsync<T>(string configPath) where T : class, new() => JsonSerializer.Deserialize<T>(await File.ReadAllTextAsync(configPath));
}