using UnityEngine;
using UnityEngine.UI;


public class UI_Timer : UI
{
    public Text TimerText {  get; private set; }

    protected override void Init()
    {
        TimerText = GetComponent<Text>();
    }

    public override void UIFunction()
    {
        int min = Mathf.FloorToInt(GameManager.Instance.Time / 60);
        int sec = Mathf.FloorToInt(GameManager.Instance.Time % 60);

        TimerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}