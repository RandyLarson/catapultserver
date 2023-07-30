namespace cat_a_pult_server;

public class GameScore
{
    public string PlayerId {get; set;}
    public string? PlayerName {get; set; }
    public int Score {get; set;}

}

public class HighScores
{
    public List<GameScore> Scores {get;set; } = new List<GameScore>();
}

