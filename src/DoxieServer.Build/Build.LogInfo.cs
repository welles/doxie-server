using JetBrains.Annotations;
using Nuke.Common;

public partial class Build
{
    [PublicAPI]
    Target LogInfo => d=> d
        .Executes(() =>
        {
            Serilog.Log.Information($"MinVer.Version = {MinVer.Version}");
            Serilog.Log.Information($"MinVer.AssemblyVersion = {MinVer.AssemblyVersion}");
            Serilog.Log.Information($"MinVer.FileVersion = {MinVer.FileVersion}");
            Serilog.Log.Information($"IsLocalBuild = {IsLocalBuild}");
            Serilog.Log.Information($"Configuration = {Configuration}");
            Serilog.Log.Information($"Dockerfile = {Dockerfile}");
            Serilog.Log.Information($"GitHubActions.RepositoryOwner = {GitHubActions?.RepositoryOwner}");
            Serilog.Log.Information($"GitHubActions.ServerUrl = {GitHubActions?.ServerUrl}");
        });
}
