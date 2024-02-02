using Nuke.Common;

public partial class Build
{
    Target Restore => d => d
        .DependsOn(Clean)
        .Executes(() =>
        {
        });
}
