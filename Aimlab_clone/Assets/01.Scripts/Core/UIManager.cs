using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [field: SerializeField, Header("Countdown UI")]
    public UI_Countdown CountdownUI { get; private set; }

    protected override void Awake()
    {
        Init();

        base.Awake();
    }

    private void Init()
    {
        if (CountdownUI == null)
            CountdownUI = FindObjectOfType<UI_Countdown>();
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