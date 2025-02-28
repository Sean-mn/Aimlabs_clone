using UnityEngine;
using UnityEngine.UI;

public class UI_Countdown : UI
{
    [field: SerializeField, Header("Countdown UI")]
    public Text CountdownText { get; private set; }

    protected override void Init()
    {
        CountdownText = GetComponent<Text>();
    }

    public override void UIFunction(float value)
    {
        CountdownText.text = value.ToString();
    }
}