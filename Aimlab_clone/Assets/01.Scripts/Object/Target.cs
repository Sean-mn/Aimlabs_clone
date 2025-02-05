using UnityEngine;
using UnityEngine.Pool;
    
public class Target : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab;
    ObjectPool<GameObject> targetPool;

    private void Start()
    {
        targetPool = new ObjectPool<GameObject>(
            CreateTarget,
            OnGetObject,
            OnReleaseObject,
            OnDestroyObject,
            collectionCheck: true,
            defaultCapacity: 6,
            maxSize: 15
            );
    }

    private GameObject CreateTarget()
    {
        return Instantiate(targetPrefab);
    }

    private void OnGetObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    private void OnReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnDestroyObject(GameObject obj)
    {
        Destroy(obj);
    }

    public void ReturnObject()
    {

    }
}