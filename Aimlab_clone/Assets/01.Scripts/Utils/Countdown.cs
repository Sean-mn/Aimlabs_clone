using System;
using System.Collections;
using UnityEngine;

public class Countdown
{
    public static IEnumerator StartCountdown(Action call)
    {
        if (UIManager.Instance?.CountdownUI == null)
        {
            Debug.LogWarning("CountdownUI = null");
            call?.Invoke();
            yield break;
        }

        WaitForSeconds delay = new WaitForSeconds(1);

        for (int i = 3; i > 0; i--)
        {
            UIManager.Instance.CountdownUI.UIFunction(i);
            yield return delay;
        }

        UIManager.Instance.CountdownUI.CountdownText.text = "Start";
        yield return delay;

        call?.Invoke();

        UIManager.Instance.CountdownUI.CountdownText.gameObject.SetActive(false);
    }
}