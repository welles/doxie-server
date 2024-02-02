using Nuke.Common;
using Nuke.Common.Tools.DotNet;

public partial class Build
{
    Target Compile => d=> d
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetTasks.DotNetBuild(s => s
                .EnableNoRestore()
                .SetProjectFile(ApiProject)
                .SetConfiguration(Configuration));
        });
}
