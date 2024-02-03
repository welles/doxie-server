using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Tools.DotNet;

public partial class Build
{
    [PublicAPI]
    Target Restore => d => d
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetTasks.DotNetRestore();
        });
}
