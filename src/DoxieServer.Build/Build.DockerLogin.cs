using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Tools.Docker;

public partial class Build
{
    [PublicAPI]
    Target DockerLogin => d => d
        .DependsOn(DockerBuild)
        .OnlyWhenStatic(() => IsServerBuild)
        .Executes(() =>
        {
            DockerTasks.DockerLogin(s => s
                .SetServer("https://ghcr.io")
                .SetUsername(GitHubActions.RepositoryOwner)
                .SetPassword(GitHubActions.Token));
        });
}
