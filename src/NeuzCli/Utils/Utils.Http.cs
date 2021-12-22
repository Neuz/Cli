using System.IO.Compression;
using System.Net.Http.Headers;
using System.Text.Json;
using Neuz.DevKit.Extensions;
using NeuzCli.Models;
using Spectre.Console;
using Spectre.Console.Extensions.Progress;

namespace NeuzCli;

/// <summary>
/// 帮助类
/// </summary>
public partial class Utils
{
    private static HttpClient HttpClient => new()
    {
        DefaultRequestHeaders =
        {
            CacheControl = new CacheControlHeaderValue
            {
                NoCache = true,
            }
        }
    };

    public static async Task<IndexCls?> GetIndexJson(string url, int timeoutSeconds = 10)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(timeoutSeconds));
        var str = await HttpClient.GetStringAsync(url, cts.Token);
        return JsonSerializer.Deserialize<IndexCls>(str);
    }

    public class DownloadTask
    {
        /// <summary>
        /// URL
        /// </summary>
        public string? Url { get; set; } = string.Empty;

        /// <summary>
        /// 本地保存文件名
        /// </summary>
        public string? LocalFileName { get; set; } = string.Empty;

        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; } = string.Empty;

        /// <summary>
        /// 解压目录
        /// </summary>
        public string? UnZipPath { get; set; } = string.Empty;
    }

    public class Downloader
    {
        private static HttpClient Client => new()
        {
            DefaultRequestHeaders =
            {
                CacheControl = new CacheControlHeaderValue
                {
                    NoCache = true,
                }
            }
        };


        private static async Task SaveFileAsync(Stream inputStream, DownloadTask task, CancellationToken token)
        {
            await using var fileStream = File.Create(task.LocalFileName!, 4096);
            inputStream.Seek(0, SeekOrigin.Begin);
            await inputStream.CopyToAsync(fileStream, token);
            await fileStream.FlushAsync(token);
        }

        public static void UnZip(DownloadTask task)
        {
            try
            {
                if (task.UnZipPath.IsNullOrEmpty()) return;
                ZipFile.ExtractToDirectory(task.LocalFileName!, task.UnZipPath!);
            }
            catch (Exception e)
            {
                AnsiConsole.WriteLine($"{task.LocalFileName} 解压失败");
                AnsiConsole.WriteException(e);
            }
        }

        public static async Task<IList<DownloadTask>> StartAsync(params DownloadTask[] tasks)
        {
            if (!tasks.Any()) throw new ArgumentException("DownloadTasks 为空");

            var cts = new CancellationTokenSource(TimeSpan.FromMinutes(10));

            var progress = AnsiConsole.Progress()
                                      .Columns(
                                          new TaskDescriptionColumn(),
                                          new ProgressBarColumn(),
                                          new PercentageColumn(),
                                          new RemainingTimeColumn(),
                                          new SpinnerColumn());
            HttpProgress? httpProgress = null;
            foreach (var task in tasks)
            {
                var message = new HttpRequestMessage(HttpMethod.Get, task.Url);

                httpProgress = httpProgress == null
                    ? progress.WithHttp(Client, message, task.Description!,
                        stream => SaveFileAsync(stream, task, cts.Token)
                            .ContinueWith(_ => UnZip(task), cts.Token))
                    : httpProgress.WithHttp(Client, message, task.Description!,
                        stream => SaveFileAsync(stream, task, cts.Token)
                            .ContinueWith(_ => UnZip(task), cts.Token));
            }

            await httpProgress?.StartAsync(cts.Token)!;
            return tasks;
        }
    }
}