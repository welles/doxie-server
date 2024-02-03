using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Tools.DotNet;

public partial class Build
{
    [PublicAPI]
    Target Compile => d=> d
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetTasks.DotNetBuild(s => s
                .EnableNoRestore()
                .SetVersion(MinVer.Version)
                .SetAssemblyVersion(MinVer.AssemblyVersion)
                .SetFileVersion(MinVer.FileVersion)
                .SetInformationalVersion(MinVer.Version)
                .SetProjectFile(ApiProject)
                .SetConfiguration(Configuration));
        });
}
