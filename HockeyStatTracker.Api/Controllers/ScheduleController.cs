using Microsoft.AspNetCore.Mvc;

namespace HockeyStatTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly PenguinsMonitorService _monitorService;

    public ScheduleController(PenguinsMonitorService monitorService)
    {
        _monitorService = monitorService;
    }

    [HttpGet("is-game-today")]
    public IActionResult CheckGameStatus()
    {
        bool isGame = _monitorService.IsThereAGameToday();
        return Ok(new { isGameToday = isGame });
    }
}