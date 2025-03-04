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

        float waitTime = 1f;

        for (int i = 3; i > 0; i--)
        {
            UIManager.Instance.CountdownUI.UIFunction(i);

            yield return WaitForSecondsCache.Wait(waitTime);
        }

        UIManager.Instance.CountdownUI.CountdownText.text = "Start";

        yield return WaitForSecondsCache.Wait(waitTime);

        call?.Invoke();

        UIManager.Instance.CountdownUI.CountdownText.gameObject.SetActive(false);
    }
}