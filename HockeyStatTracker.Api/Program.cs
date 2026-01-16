using HockeyStatTracker.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<PenguinsMonitorService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
