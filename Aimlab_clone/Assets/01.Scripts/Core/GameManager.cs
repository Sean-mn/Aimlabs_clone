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
        SetMaxTime(90f);
        GameTime = GetMaxTime();
    }

    private void Update()
    {
        if (!IsGameStart || IsGameOver) return;

        UpdateTime();
    }

    public void InitGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(Countdown.StartCountdown(GameStart));
    }

    private void UpdateTime()
    {
        GameTime = Mathf.Max(0, GameTime - Time.deltaTime);

        if (GameTime <= 0)
            GameOver();
    }

    public void GameStart()
    {
        onGameStart?.Invoke();

        IsGameStart = true;
        IsGameOver = false;
    }

    public void GameOver()
    {
        IsGameOver = true;
        IsGameStart = false;

        onGameOver?.Invoke();
    }

    public float GetMaxTime()
    {
        return MaxGameTime;
    }

    public void SetMaxTime(float maxTime)
    {
        MaxGameTime = maxTime;
    }
}
