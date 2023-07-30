using Newtonsoft.Json.Linq;

namespace cat_a_pult_server;

public class GameScore
{
    public string PlayerId { get; set; }
    public string? PlayerName { get; set; }
    public int Score { get; set; }

}


public class Persistence
{
    static public string DataPath = "./data/highscores.json";
    static public HighScores LoadHighScores()
    {
        try
        {
            if (File.Exists(DataPath))
            {
                var asJObject = JObject.Parse(File.ReadAllText(DataPath));
                return asJObject.ToObject<HighScores>();
            }
            return new HighScores();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new HighScores();
        }
    }

    static public void SaveHighScores(HighScores toSave)
    {
        try{
            if ( toSave != null)
            {

            var asJObject = JObject.FromObject(toSave);
            File.WriteAllText(DataPath, asJObject.ToString());
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

public class HighScores
{
    public List<GameScore> Scores { get; set; } = new List<GameScore>();
}

