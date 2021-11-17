using Flurl.Http;
using NeuzCli.Models;

namespace NeuzCli;

/// <summary>
/// 帮助类
/// </summary>
public partial class Utils
{
    public static async Task<IndexCls> GetIndexJson(string url, int timeout = 10) => await url.WithTimeout(timeout).GetJsonAsync<IndexCls>();
}