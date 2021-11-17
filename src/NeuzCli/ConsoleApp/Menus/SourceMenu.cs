using NeuzCli.ConsoleApp.Features;
using Spectre.Console;

namespace NeuzCli.ConsoleApp;

public partial class Menus
{
    public static MenuCls SourceMenu = new()
    {
        Name        = "SourceFeature",
        Description = "源管理",
        Action = _ => SourceFeature.ShowSourceInfo(),
        SubMenus = new[]
        {
            SourceMenus.Set,
            SourceMenus.Reset,
            SourceMenus.Update,
        }
    };
}

public class SourceMenus
{
    public static MenuCls Set = new()
    {
        Name        = "SourceFeature.Set",
        Description = "设置",
        Action      = _ => SourceFeature.SetSource()
    };

    public static MenuCls Reset = new()
    {
        Name        = "SourceFeature.Reset",
        Description = "还原",
        Action      = _ => SourceFeature.ResetSource()
    };

    public static MenuCls Update = new()
    {
        Name        = "SourceFeature.Update",
        Description = "更新",
        Action      = _ => SourceFeature.UpdateSource()
    };
}