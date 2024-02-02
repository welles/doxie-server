﻿using Nuke.Common;

public partial class Build
{
    Target LogInfo => d=> d
        .Executes(() =>
        {
            Serilog.Log.Information($"MinVer        = {MinVer.Version}");
            Serilog.Log.Information($"IsLocalBuild  = {IsLocalBuild}");
            Serilog.Log.Information($"Configuration = {Configuration}");
            Serilog.Log.Information($"Dockerfile    = {Dockerfile}");
        });
}
