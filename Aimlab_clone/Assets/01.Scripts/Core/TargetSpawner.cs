using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject targetPrefab;

    [SerializeField]
    private List<Transform> targetPoses = new List<Transform>();

    public HashSet<Vector3> usedPoses = new HashSet<Vector3>();

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
            if (!usedPoses.Contains(mixedPoses[i].position))
            {
                Instantiate(targetPrefab, mixedPoses[i].position, Quaternion.identity);
                usedPoses.Add(mixedPoses[i].position);
            }
        }
    }

    public IEnumerator Spawn()
    {
        float waitTime = 0.01f;

        yield return WaitForSecondsCache.Wait(waitTime);

        Transform spawnPos = CheckAvailablePosition();

        if (spawnPos != null)
        {
            Instantiate(targetPrefab, spawnPos.position, Quaternion.identity);
            usedPoses.Add(spawnPos.position);
        }
    }

    private Transform CheckAvailablePosition()
    {
        List<Transform> available = new List<Transform>();

        for (int i = 0; i < targetPoses.Count; i++)
        {
            if (!usedPoses.Contains(targetPoses[i].position))
            {
                available.Add(targetPoses[i]);
            }
        }

        if (available.Count <= 0) return null;

        return available[Random.Range(0, available.Count)];
    }
}