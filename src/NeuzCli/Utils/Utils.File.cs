using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace NeuzCli;

/// <summary>
/// 帮助类
/// </summary>
public partial class Utils
{
    private static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new()
    {
        WriteIndented = true,
        Encoder       = JavaScriptEncoder.Create(UnicodeRanges.All)
    };

    public static async Task<T> WriteFileAsync<T>(T obj, string filePath) where T : class?, new()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
        await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(obj, DefaultJsonSerializerOptions));
        return obj;
    }

    public static async Task<T?> ReadFileAsync<T>(string filePath) where T : class, new()
    {
        return JsonSerializer.Deserialize<T>(await File.ReadAllTextAsync(filePath));
    }
}