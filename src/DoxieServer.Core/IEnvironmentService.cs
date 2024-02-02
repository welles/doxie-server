namespace DoxieServer.Core;

public interface IEnvironmentService
{
    /// <summary>
    /// The path on the server where the files will be placed.
    /// </summary>
    public string TargetPath { get; }
}
