using UnityEngine;
using UnityEngine.UI;

public class UI_ShowScore : UI
{
    [field: SerializeField, Header("Score Text")]
    public Text ScoreText { get; private set; }

    protected override void Init()
    {
        ScoreText= GetComponent<Text>();
    }
}
