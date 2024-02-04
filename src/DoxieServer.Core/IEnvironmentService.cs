namespace DoxieServer.Core;

public interface IEnvironmentService
{
    /// <summary>
    /// Returns a string showing an overview over all configuration values.
    /// </summary>
    public string ConfigurationValues { get; }

    /// <summary>
    /// Whether the local path is enabled.
    /// </summary>
    public bool LocalPathEnabled { get; }

    /// <summary>
    /// The path on the server where the files will be placed.
    /// </summary>
    public string LocalPathTargetPath { get; }
}
