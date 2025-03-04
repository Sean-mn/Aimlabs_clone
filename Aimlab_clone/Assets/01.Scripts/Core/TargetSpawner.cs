using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject targetPrefab;

    [SerializeField]
    private List<Transform> targetPoses = new List<Transform>();

    private void OnEnable()
    {
        GameManager.Instance.onGameStart -= FirstCreateTargets;
        GameManager.Instance.onGameStart += FirstCreateTargets;
    }

    private void OnDestroy()
    {
        GameManager.Instance.onGameStart -= FirstCreateTargets;
    }

    private void FirstCreateTargets()
    {
        if (targetPoses.Count < 7) return;

        List<Transform> mixedPoses = new List<Transform>(targetPoses);
        for (int i = mixedPoses.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            (mixedPoses[i], mixedPoses[randomIndex]) = (mixedPoses[randomIndex], mixedPoses[i]);
        }

        for (int i = 0; i < 7; i++)
        {
            Instantiate(targetPrefab, mixedPoses[i].position, Quaternion.identity);
        }
    }

    public IEnumerator Spawn()
    {
        float waitTime = 0.01f;

        yield return WaitForSecondsCache.Wait(waitTime);

        int createPos = Random.Range(0, targetPoses.Count);

        Instantiate(targetPrefab, targetPoses[createPos].position, Quaternion.identity);
    }
}