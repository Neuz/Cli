using Flurl.Http;
using NeuzCli.Models;

namespace NeuzCli;

/// <summary>
/// 帮助类
/// </summary>
public partial class Utils
{
    public static async Task<IndexCls> QueryIndex(string url)
    {
        return await url.WithTimeout(10).GetJsonAsync<IndexCls>();
    }
}