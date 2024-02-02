using DoxieServer.Core;
using FastEndpoints;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddSingleton<IEnvironmentService, EnvironmentService>();

var app = builder.Build();
app.UseFastEndpoints();
app.Run();
