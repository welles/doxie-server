using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Git;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.MinVer;

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

    [MinVer]
    readonly MinVer MinVer;

    [Parameter]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [CanBeNull]
    GitHubActions GitHubActions => GitHubActions.Instance;

    [GitRepository]
    readonly GitRepository GitRepository;

    [Solution(GenerateProjects = true)]
    readonly Solution Solution;

    Project CoreProject => Solution.DoxieServer_Core;

    Project ApiProject => Solution.DoxieServer_Api;
}
