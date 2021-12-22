using System.Diagnostics;
using Neuz.DevKit.Extensions;

namespace NeuzCli;

/// <summary>
/// 帮助类
/// </summary>
public partial class Utils
{
    public static Task ExecuteExe(string fileName, string args = "")
    {
        if (!File.Exists(fileName)) throw new FileNotFoundException("文件无法找到", fileName);
        var process = Process.Start(new ProcessStartInfo()
        {
            CreateNoWindow  = true,
            UseShellExecute = false,
            FileName        = fileName,
            Arguments       = args,
            // Verb            = "RunAs"
        });

        return process.WaitForExitAsync();
    }

    public static Task ExecuteBatFile(string fileName, string args = "", DataReceivedEventHandler? outputHandler = null, DataReceivedEventHandler? errorHandler = null)
    {
        if (!File.Exists(fileName)) throw new FileNotFoundException("文件无法找到", fileName);
        var script = args.IsNullOrEmpty()
            ? fileName
            : $"{fileName} {args}";
        return ExecuteScript(script);
    }


    public static Task ExecuteScript(string script, DataReceivedEventHandler? outputHandler = null, DataReceivedEventHandler? errorHandler = null)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName               = "cmd.exe",
                Arguments              = $"/c {script}",
                UseShellExecute        = false,
                RedirectStandardOutput = true,
                RedirectStandardError  = true,
            },
        };

        if (outputHandler != null) process.OutputDataReceived += outputHandler;
        if (errorHandler != null) process.ErrorDataReceived   += errorHandler;

        process.Start();
        process.BeginOutputReadLine();
        return process.WaitForExitAsync();
    }
}