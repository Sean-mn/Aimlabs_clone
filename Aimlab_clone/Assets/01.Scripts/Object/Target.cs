using System.Collections;
using UnityEngine;
using static Define;
    
public class Target : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab;

    [SerializeField] TargetSpawner targetSpawner;

    private void Awake()
    {
        targetPrefab = GetComponent<GameObject>();
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
        ScoreManager.Instance.AddScore(100, UIManager.Instance.ShowScoreUI.UIFunction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.Target))
        {

        }
    }
}