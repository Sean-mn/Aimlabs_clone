using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text timer;

    private void Update()
    {
        TimerText();
    }

    private void TimerText()
    {
        timer.text = string.Format("{0:D2}:{1:D2}", GameManager.Instance.min, (int)GameManager.Instance.sec);
    }
}