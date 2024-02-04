using DoxieServer.Api;
using DoxieServer.Core;
using FastEndpoints;
using Serilog;

var builder = WebApplication.CreateBuilder();
builder.Services.AddSerilog(c => c.WriteTo.Console());
builder.Services.AddFastEndpoints();
builder.Services.AddHostedService<ConfigurationOverviewService>();

builder.Services.AddSingleton<IEnvironmentService>(new EnvironmentService());

var app = builder.Build();
app.UseFastEndpoints();
app.Run();
