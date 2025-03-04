using UnityEngine;

public class ScoreManager : MonoSingleton<ScoreManager>
{
    [field: SerializeField, Header("Score")]
    public int Score { get; set; }

    public void AddScore(int amount)
    {
        Score += amount;
    }

    public void ResetScore()
    {
        Score = 0;
    }
}