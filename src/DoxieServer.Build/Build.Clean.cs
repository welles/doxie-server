using Nuke.Common;
using Nuke.Common.Tools.DotNet;

public partial class Build
{
    Target Clean => d => d
        .DependsOn(LogInfo)
        .Executes(() =>
        {
            DotNetTasks.DotNetClean(s => s.SetProject(CoreProject));
            DotNetTasks.DotNetClean(s => s.SetProject(ApiProject));
        });
}
