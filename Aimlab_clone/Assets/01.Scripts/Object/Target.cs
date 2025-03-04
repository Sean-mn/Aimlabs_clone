using UnityEngine;
    
public class Target : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab;

    private void Awake()
    {
        targetPrefab = GetComponent<GameObject>();
    }

    public void Catched()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        ScoreManager.Instance.AddScore(100);
    }
}