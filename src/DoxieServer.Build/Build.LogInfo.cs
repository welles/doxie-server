using Nuke.Common;

public partial class Build
{
    Target LogInfo => d=> d
        .Executes(() =>
        {
            Serilog.Log.Information($"MinVer.Version = {MinVer.Version}");
            Serilog.Log.Information($"MinVer.AssemblyVersion = {MinVer.AssemblyVersion}");
            Serilog.Log.Information($"MinVer.FileVersion = {MinVer.FileVersion}");
            Serilog.Log.Information($"IsLocalBuild = {IsLocalBuild}");
            Serilog.Log.Information($"Configuration = {Configuration}");
            Serilog.Log.Information($"Dockerfile = {Dockerfile}");
        });
}
