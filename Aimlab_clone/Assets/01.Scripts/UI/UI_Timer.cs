using UnityEngine;
using UnityEngine.UI;


public class UI_Timer : UI
{
    [field: SerializeField, Header("Timer UI")]
    public Text TimerText { get; private set; }

    protected override void Init()
    {
        TimerText = GetComponent<Text>();
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameOver)
            UIManager.Instance.DisableUI<Text>(TimerText);
        else
            UIManager.Instance.ActiveUI<Text>(TimerText);

        UIFunction();
    }

    public override void UIFunction()
    {
        int min = Mathf.FloorToInt(GameManager.Instance.GameTime / 60);
        int sec = Mathf.FloorToInt(GameManager.Instance.GameTime % 60);

        TimerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}