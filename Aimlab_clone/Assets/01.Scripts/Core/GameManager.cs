using UnityEngine;
using System;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField, Header("Score")]
    private int score;
    public int Score => score;

    [field: SerializeField, Header("Timer")]
    public float GameTime { get; private set; }

    [field: SerializeField, Header("Game Triggers")]
    public bool IsGameStart { get; private set; } = false;
    [field: SerializeField]
    public bool IsGameOver { get; private set; } = false;

    [field: SerializeField, Header("Reference")]
    public CameraRotation CameraRotate { get; private set; }

    public event Action onGameStart;
    public event Action onGameOver;

    protected override void Awake()
    {
        base.Awake();

        if (CameraRotate == null)
        {
            CameraRotate = FindAnyObjectByType<CameraRotation>();
        }
    }

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
        score = 0;

        StartCoroutine(Countdown.StartCountdown(GameStart));
    }

    private void UpdateTime()
    {
        GameTime = Mathf.Max(0, GameTime + Time.deltaTime);
    }

    public void GameStart()
    {
        IsGameStart = true;
        IsGameOver = false;
        onGameStart?.Invoke();
    }

    public void GameOver()
    {
        if (IsGameOver) return;

        IsGameOver = true;
        IsGameStart = false;

        onGameOver?.Invoke();
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
