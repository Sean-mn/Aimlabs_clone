using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [field: SerializeField, Header("Countdown UI")]
    public UI_Countdown CountdownUI { get; private set; }

    [field: SerializeField, Header("Show Score UI")]
    public UI_ShowScore ShowScoreUI { get; private set; }

    [field: SerializeField, Header("GameOver UI")]
    public UI_GameOver GameOverUI { get; private set; }
    
    public void InitUI()
    {
        if (CountdownUI == null)
            CountdownUI = FindObjectOfType<UI_Countdown>();

        if (GameOverUI == null)
            GameOverUI = FindObjectOfType<UI_GameOver>();

        if (ShowScoreUI == null)
            ShowScoreUI = FindObjectOfType<UI_ShowScore>();
    }

    public void ActiveUI<T>(T ui) where T : Component
    {
        ui?.gameObject?.SetActive(true);
    }

    public void DisableUI<T> (T ui) where T : Component
    {
        ui?.gameObject?.SetActive(false);
    }
}