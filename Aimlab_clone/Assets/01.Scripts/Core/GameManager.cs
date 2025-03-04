using UnityEngine;
using System;

public class GameManager : MonoSingleton<GameManager>
{
    [field: SerializeField, Header("Timer")]
    public float GameTime { get; private set; }
    public float MaxGameTime;

    [field: SerializeField, Header("Game Triggers")]
    public bool IsGameStart { get; private set; } = false;
    [field: SerializeField]
    public bool IsGameOver { get; private set; } = false;

    public event Action onGameStart;
    public event Action onGameOver;

    private void Start()
    {
        InitGame();
    }

    private void Update()
    {
        if (!IsGameStart || IsGameOver) return;

        UpdateTime();
    }

    private void InitGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameTime = 0;
        MaxGameTime = 20;

        StartCoroutine(Countdown.StartCountdown(GameStart));
    }

    private void UpdateTime()
    {
        GameTime = Mathf.Max(0, GameTime + Time.deltaTime);
    }

    public void GameStart()
    {
        onGameStart?.Invoke();
        IsGameStart = true;
        IsGameOver = false;
    }

    public void GameOver()
    {
        if (IsGameOver) return;

        IsGameOver = true;
        IsGameStart = false;

        onGameOver?.Invoke();
    }
}
