﻿using NeuzCli.ConsoleApp.Models;

namespace NeuzCli.ConsoleApp
{
    internal partial class Menus
    {
        public static MenuCls ExitMenu = new()
        {
            Name        = "Exit",
            Description = "退出",
            Action      = _ => Environment.Exit(0)
        };
    }
}