using System;

[Serializable]
public class GameLevel
{
    public void SetLevelTime(Define.GameLevel level)
    {
        float maxTime = GetMaxTimeForLevel(level);
        GameManager.Instance.SetMaxTime(maxTime);
    }

    public float GetMaxTimeForLevel(Define.GameLevel level)
    {
        return level switch
        {
            Define.GameLevel.Easy => 80f,
            Define.GameLevel.Normal => 50f,
            Define.GameLevel.Hard => 30f,
            _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
        };
    }
}