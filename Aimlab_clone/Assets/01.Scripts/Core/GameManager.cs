using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField, Header("Score")]
    private int score;
    public int Score {  get { return score; } }

    [field: SerializeField, Header("Timer")]
    public float Time {  get; private set; }

    [Header("Game Trigger")]
    public bool isGameStart = false;
    public bool isGameOver = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        UpdataTime();
    }

    public void UpdataTime()
    {
        if (isGameOver) return;

        Time += UnityEngine.Time.deltaTime;
    }

    public void GameStart()
    {
        isGameStart = true;
        Time = 0;
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over");
    }
}