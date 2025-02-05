using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static readonly object _lock = new object();
    protected static bool isShutdown = false;

    public static T Instance
    {
        get
        {
            if (isShutdown)
            {
                return null;
            }

            // 쓰레드 안정화
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        GameObject obj = new GameObject(typeof(T).Name, typeof(T));
                        _instance = obj.GetComponent<T>();
                    }
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            isShutdown = false;
            _instance = null;
        }
    }

    protected virtual void OnApplicationQuit()
    {
        isShutdown = true;
    }
}