using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Tools.Docker;

public partial class Build
{
    [PublicAPI]
    Target DockerPushDev => d => d
        .DependsOn(DockerLogin)
        .OnlyWhenStatic(() => IsServerBuild)
        .Executes(() =>
        {
            DockerTasks.DockerPush(s => s
                .SetName("doxie-server:dev"));
        });
}
