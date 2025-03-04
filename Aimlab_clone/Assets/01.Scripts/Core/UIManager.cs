using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [field: SerializeField, Header("Countdown UI")]
    public UI_Countdown CountdownUI { get; private set; }
    [field: SerializeField, Header("GameOver UI")]
    public UI_GameOver GameOverUI { get; private set; }

    protected override void Awake()
    {
        Init();

        base.Awake();
    }

    private void Init()
    {
        if (CountdownUI == null)
            CountdownUI = FindObjectOfType<UI_Countdown>();

        if (GameOverUI == null)
            GameOverUI = FindObjectOfType<UI_GameOver>();
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