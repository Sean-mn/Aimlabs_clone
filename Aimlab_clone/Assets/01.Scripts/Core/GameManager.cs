using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public int score;

    [Header("Timer")]
    public float sec = 20;
    public int min = 1;

    public bool isGameOver = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!isGameOver)
        {
            Timer();
        }
    }

    public void Timer()
    {
        if (!isGameOver && min <= 0 && sec <= 0)
        {
            GameOver();
            return;
        }

        sec -= Time.deltaTime; 

        if (sec < 0)
        {
            if (min > 0)
            {
                min -= 1;
                sec = 59;
            }
            else
            {
                sec = 0;
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("Game Over");
    }
}