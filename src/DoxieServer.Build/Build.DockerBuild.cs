﻿using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.Docker;

public partial class Build
{
    AbsolutePath Dockerfile => Solution.DoxieServer_Api.Directory / "Dockerfile";

    [PublicAPI]
    Target DockerBuild => d => d
        .DependsOn(Compile)
        .Executes(() =>
        {
            DockerTasks.DockerBuild(s =>
                s.SetFile(Dockerfile)
                 .SetPath(Solution.Directory)
                 .SetTag("doxie-server:dev"));
        });
}
