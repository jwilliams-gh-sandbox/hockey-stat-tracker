using HockeyStatTracker.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PenguinsMonitorService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();