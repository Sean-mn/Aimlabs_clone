using UnityEngine;
using System;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField, Header("Score")]
    private int score;
    public int Score => score;

    [field: SerializeField, Header("Timer")]
    public float GameTime { get; private set; }

    [field: SerializeField,Header("Game Trigger")]
    public bool IsGameStart { get; private set; } = false;
    [field: SerializeField, Header("Game Trigger")]
    public bool IsGameOver { get; private set; } = false;

    public event Action onGameStart;
    public event Action onGameOver;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(Countdown.StartCountdown(GameStart));
    }

    private void Update()
    {
        if (!IsGameStart || IsGameOver) return;

        UpdateTime();
    }

    private void UpdateTime()
    {
        GameTime += Time.deltaTime;
    }

    public void GameStart()
    {
        IsGameStart = true;
        IsGameOver = false;
        GameTime = 0;
        score = 0;
        onGameStart?.Invoke();
    }

    public void GameOver()
    {
        IsGameOver = true;
        IsGameStart = false;
        Debug.Log("Game Over");
        onGameOver?.Invoke();
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}