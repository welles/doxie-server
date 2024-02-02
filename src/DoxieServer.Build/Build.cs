using Nuke.Common;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.ProjectModel;

[GitHubActions(
    nameof(Build.Compile),
    GitHubActionsImage.UbuntuLatest,
    OnPushBranches = new[]
    {
        "*"
    },
    FetchDepth = 0,
    InvokedTargets = new []
    {
        nameof(Build.Compile)
    }
)]
public partial class Build : NukeBuild
{
    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    GitHubActions GitHubActions => GitHubActions.Instance;

    [Solution(GenerateProjects = true)]
    readonly Solution Solution;

    Project CoreProject => Solution.DoxieServer_Core;

    Project ApiProject => Solution.DoxieServer_Api;
}
