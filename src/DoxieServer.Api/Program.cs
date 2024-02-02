using DoxieServer.Core;
using FastEndpoints;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddSingleton<IEnvironmentService>(new EnvironmentService());

var app = builder.Build();
app.UseFastEndpoints();
app.Run();
