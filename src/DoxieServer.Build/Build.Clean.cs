using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Tools.DotNet;

public partial class Build
{
    [PublicAPI]
    Target Clean => d => d
        .DependsOn(LogInfo)
        .Executes(() =>
        {
            DotNetTasks.DotNetClean(s => s.SetProject(CoreProject));
            DotNetTasks.DotNetClean(s => s.SetProject(ApiProject));
        });
}
