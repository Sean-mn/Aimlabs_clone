using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] TargetSpawner targetSpawner;

    private void Awake()
    {
        targetSpawner = FindAnyObjectByType<TargetSpawner>();
    }

    public IEnumerator Catched()
    {
        Coroutine spawn = StartCoroutine(targetSpawner.Spawn());

        yield return spawn;

        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        targetSpawner.usedPoses.Remove(transform.position);
        ScoreManager.Instance.AddScore(100, UIManager.Instance.ShowScoreUI.UIFunction);
    }
}