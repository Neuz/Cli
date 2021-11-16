using NeuzCli.CliApp.Commands;
using NeuzCli.CliApp.Commands.App;
using NeuzCli.CliApp.Commands.Source;
using Spectre.Console.Cli;

namespace NeuzCli.CliApp
{
    public class CliApp
    {
        public int Run(string[] args)
        {
            Features.Initialization();

            var app = new CommandApp();
            app.Configure(appConf =>
            {
                appConf.Settings.ApplicationName    = "NeuzCli.exe";
                appConf.Settings.ApplicationVersion = "v0.1";

                #region Info

                appConf.AddCommand<SystemInfoCommand>("info")
                       .WithDescription(SystemInfoCommand.Description);

                #endregion

                #region source

                appConf.AddBranch("source", sourceConf =>
                {
                    sourceConf.SetDescription("源管理");

                    sourceConf.AddCommand<SourceSetCommand>("set")
                              .WithDescription(SourceSetCommand.Description);

                    sourceConf.AddCommand<SourceShowCommand>("show")
                              .WithDescription(SourceShowCommand.Description);

                    sourceConf.AddCommand<SourceResetCommand>("reset")
                              .WithDescription(SourceResetCommand.Description);
                });

                #endregion

                #region app

                appConf.AddBranch("app", addConf =>
                {
                    addConf.SetDescription("应用管理");

                    addConf.AddCommand<AppListCommand>("list")
                           .WithDescription(AppListCommand.Description);

                    addConf.AddCommand<AppSearchCommand>("search")
                           .WithDescription(AppSearchCommand.Description);

                    addConf.AddCommand<AppAddCommand>("add")
                           .WithDescription(AppAddCommand.Description);

                    addConf.AddCommand<AppRemoveCommand>("remove")
                           .WithDescription(AppRemoveCommand.Description);

                    addConf.AddCommand<AppRunCommand>("run")
                           .WithDescription(AppRunCommand.Description);
                });

                #endregion
            });

            return app.Run(args);
        }
    }
}