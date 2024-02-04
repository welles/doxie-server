using DoxieServer.Core;
using Serilog;

namespace DoxieServer.Api;

public class ConfigurationOverviewService(IEnvironmentService environmentService) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Log.Logger.Information(environmentService.ConfigurationValues);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
