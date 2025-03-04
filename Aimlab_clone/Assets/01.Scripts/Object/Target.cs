using UnityEngine;
    
public class Target : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab;

    private void Awake()
    {
        targetPrefab = GetComponent<GameObject>();
    }

    private void OnDisable()
    {
        ScoreManager.Instance.AddScore(100);
    }
}