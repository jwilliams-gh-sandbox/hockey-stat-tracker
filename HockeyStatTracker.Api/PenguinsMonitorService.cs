using HockeyStatTracker.Api.Models;
using System.Net.Http.Json;

namespace HockeyStatTracker.Api;

public class PenguinsMonitorService : BackgroundService
{
    private readonly ILogger<PenguinsMonitorService> _logger;
    private readonly HttpClient _httpClient;

    /* /bin/sh
        curl --request GET \                                                                                                                                     ─╯
        --url "https://api-web.nhle.com/v1/club-schedule/PIT/week/now" \
        --location | jq
    */
    private const string PitScheduleUrl = "https://api-web.nhle.com/v1/club-schedule/PIT/week/now";
    private const string LiveGameUrl = "https://api-web.nhle.com/v1/gamecenter/{0}/play-by-play";

    public PenguinsMonitorService(ILogger<PenguinsMonitorService> logger)
    {
        _logger = logger;
        _httpClient = new HttpClient();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Wake up! Checking for Penguins game at: {time}", DateTimeOffset.Now);

            var gameId = await GetGameIdForToday();

            if (gameId.HasValue)
            {
                _logger.LogInformation("Game found! ID: {id}. Switching to Live Monitor mode.", gameId);
                await MonitorLiveGame(gameId.Value, stoppingToken);
            }
            else
            {
                _logger.LogInformation("No game today. Going back to sleep until tomorrow.");
            }
            
            // check once today/now and delay until tomorrow
            // TODO: improve this to handle cancelled or postponed games. also consider
            // syncing scheduling games ahead of time instead of polling daily.
            await Task.Delay(CalculateTimeToNextCheck(), stoppingToken);
        }
    }

    private async Task<int?> GetGameIdForToday()
    {
        try
        {
            var today = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var response = await _httpClient.GetFromJsonAsync<NhlScheduleResponse>(PitScheduleUrl);
            
            // find today's game
            var game = response?.Games?.FirstOrDefault(g => g.GameDate == today);
            return game?.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch schedule.");
            return null;
        }
    }

    private async Task MonitorLiveGame(int gameId, CancellationToken stoppingToken)
    {
        // TODO: placeholder for live game monitoring logic
        _logger.LogInformation("Monitoring game {id} for goals...", gameId);
        await Task.CompletedTask; 
    }

    private TimeSpan CalculateTimeToNextCheck()
    {
        var now = DateTime.Now;
        var tomorrow = now.AddDays(1).Date.AddMinutes(1); // 12:01 AM tomorrow
        return tomorrow - now;
    }
}

public record NhlScheduleResponse(List<NhlGame> Games);
public record NhlGame(int Id, string GameDate);