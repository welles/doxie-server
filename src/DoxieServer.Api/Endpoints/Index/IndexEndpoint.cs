using System.Reflection;
using DoxieServer.Core;
using FastEndpoints;
using JetBrains.Annotations;

namespace DoxieServer.Api.Endpoints.Index;

[PublicAPI]
public class IndexEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        this.AllowAnonymous();
        this.Get("/");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = $"Service is running.\n\nBuild {Assembly.GetExecutingAssembly().GetVersion()} ({Assembly.GetExecutingAssembly().GetBuildDate():dd.MM.yyyy HH:mm:ss})";

        await this.SendStringAsync(result, cancellation: ct);
    }
}
