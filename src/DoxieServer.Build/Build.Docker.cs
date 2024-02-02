using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.Docker;
using Nuke.Common.Tools.GitHub;

public partial class Build
{
    AbsolutePath Dockerfile => Solution.DoxieServer_Api.Directory / "Dockerfile";

    Target Docker => d => d
        .DependsOn(Compile)
        .OnlyWhenDynamic(() => IsServerBuild)
        .Executes(() =>
        {
            DockerTasks.DockerBuild(s =>
                s.SetFile(Dockerfile)
                 .SetPath(Solution.Directory)
                 .SetLabel("doxie-server")
                 .SetTag("dev"));
        });
}
