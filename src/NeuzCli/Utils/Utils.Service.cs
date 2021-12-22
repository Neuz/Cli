using System.ServiceProcess;
using Neuz.DevKit.Extensions;

// ReSharper disable ReplaceWithSingleCallToFirstOrDefault

namespace NeuzCli;

/// <summary>
/// 帮助类
/// </summary>
public partial class Utils
{
    public static ServiceController? GetServiceController(string serviceName)
    {
        return ServiceController.GetServices()
                                .Where(s => s.ServiceName.CaseCmp(serviceName))
                                .FirstOrDefault();
    }
}