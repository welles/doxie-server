namespace DoxieServer.Core;

public class EnvironmentService : IEnvironmentService
{
    public EnvironmentService()
    {
        this.TargetPath = this.TryGetEnvironmentVariable(EnvironmentVariables.TargetPath);
    }

    /// <inheritdoc />
    public string TargetPath { get; }

    private string TryGetEnvironmentVariable(string name)
    {
        var value = Environment.GetEnvironmentVariable(name);

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException($"The environment variable with name \"{name}\" has not been set!");
        }

        return value;
    }
}
