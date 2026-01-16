namespace HockeyStatTracker.Api.Models;

public record GameUpdate(
    int GameId,
    string HomeTeam,
    string AwayTeam,
    int HomeScore,
    int AwayScore,
    string UpdateTime,
    List<GoalEvent> NewGoals
);

public record GoalEvent(
    string Scorer,
    string AssistPrimary,
    string AssistSecondary,
    string TimeScored
);