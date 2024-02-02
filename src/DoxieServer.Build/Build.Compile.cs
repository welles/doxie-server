using Nuke.Common;

public partial class Build
{
    Target Compile => d=> d
        .DependsOn(Restore)
        .Executes(() =>
        {
        });
}
