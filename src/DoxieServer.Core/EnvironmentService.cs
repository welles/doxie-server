using System.Text;

namespace DoxieServer.Core;

public class EnvironmentService : IEnvironmentService
{
    public EnvironmentService()
    {
        this.LocalPathEnabled = this.GetEnvironmentVariable(EnvironmentVariables.LocalPathEnabled, true);
        this.LocalPathTargetPath = this.GetEnvironmentVariable(EnvironmentVariables.LocalPathTargetPath, "/etc/scans");
    }

    /// <inheritdoc />
    public bool LocalPathEnabled { get; }

    /// <inheritdoc />
    public string LocalPathTargetPath { get; }

    public string ConfigurationValues
    {
        get
        {
            var sb = new StringBuilder();
            sb.AppendLine("CONFIGURATION VALUES:");
            sb.AppendLine($"{EnvironmentVariables.LocalPathEnabled} = {LocalPathEnabled}");
            sb.AppendLine($"{EnvironmentVariables.LocalPathTargetPath} = {LocalPathTargetPath}");

            return sb.ToString();
        }
    }

    private T GetEnvironmentVariable<T>(string name, T defaultValue)
        where T : IConvertible
    {
        var value = Environment.GetEnvironmentVariable(name);

        if (value == null)
        {
            return defaultValue;
        }

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException($"The environment variable with name \"{name}\" has not been set!");
        }

        T result;

        try
        {
            result = (T) Convert.ChangeType(value, typeof(T));
        }
        catch
        {
            throw new InvalidOperationException(
                $"The environment variable with name \"{name}\" and value \"{value}\" cannot be converted to type \"{nameof(T)}\"");
        }

        return result;
    }
}
