using System;
using UnityEngine;

public class ScoreManager : MonoSingleton<ScoreManager>
{
    [field: SerializeField, Header("Score")]
    public int Score { get; set; }

    public void AddScore(int amount, Action call)
    {
        Score += amount;
        call?.Invoke();
    }

    public void ResetScore()
    {
        Score = 0;
    }
}