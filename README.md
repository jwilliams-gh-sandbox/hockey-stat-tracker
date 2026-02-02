# Hockey Stat Tracker
This repo is primarily to practice C# and react. The idea for a "hockey stat tracker" came to me while trying to think of a simple app while watching/listening to a Penguins :penguin: game in the background. Why not build an app that queries for, captures, and presents scores live while I'm paying more attention to building the app :thinking:...

### Steps to run
1. `git clone https://github.com/jwilliams-gh-sandbox/hockey-stat-tracker.git`
2. `dotnet run --project ./HockeyStatTracker.Api/HockeyStatTracker.Api.csproj`
3. On a game day you'll see something similar to:
```shell
Using launch settings from ./Properties/launchSettings.json...
Building...
info: HockeyStatTracker.Api.PenguinsMonitorService[0]
      Wake up! Checking for Penguins game at: 02/02/2026 18:43:07 -05:00
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5032
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /hockey-stat-tracker/HockeyStatTracker.Api
info: HockeyStatTracker.Api.PenguinsMonitorService[0]
      Game found! ID: 2025020877. Switching to Live Monitor mode.
info: HockeyStatTracker.Api.PenguinsMonitorService[0]
      Monitoring game 2025020877 for goals...
```