public class GameLevelManager
{
    public GameLevel GameLevel {  get; set; }

    public GameLevelManager(GameLevel gameLevel)
    {
        GameLevel = gameLevel;
    }

    public void SetLevel(Define.GameLevel level)
    {
        GameLevel.SetLevelTime(level);
    }
}