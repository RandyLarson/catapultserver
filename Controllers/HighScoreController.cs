using Microsoft.AspNetCore.Mvc;

namespace cat_a_pult_server.Controllers;

[ApiController]
[Route("[controller]")]
public class HighScoreController : ControllerBase
{
    private ILogger<HighScoreController> Logger { get; }
    private HighScores Scoresheet { get; }

    public HighScoreController(ILogger<HighScoreController> logger, HighScores scoresheet)
    {
        Logger = logger;
        Scoresheet = scoresheet;
    }

    [HttpGet(Name = "GetHighScores")]
    public HighScores Get(bool all = false)
    {
        // Scoresheet.Scores.Add( new GameScore(){ 
        //     PlayerId = Guid.NewGuid().ToString(),
        //     PlayerName = "Frodo",
        //     Score = Random.Shared.Next(2000)
        // });

        if (all)
        {
            return new HighScores
            {
                Scores = Scoresheet.Scores.ToList()
            };
        }
        
        return new HighScores
        {
            Scores = Scoresheet.Scores.OrderByDescending(m => m.Score).Take(10).ToList()
        };
    }

    [HttpPost(Name = "AddScore")]
    public HighScores Add(GameScore score)
    {
        Scoresheet.Scores.Add(score);
        return Get();
    }
}
