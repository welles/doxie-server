using Nuke.Common;
using Nuke.Common.Tools.DotNet;

public partial class Build
{
    Target Restore => d => d
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetTasks.DotNetRestore();
        });
}
