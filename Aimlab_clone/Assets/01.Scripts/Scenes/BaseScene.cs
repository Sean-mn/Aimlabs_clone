using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType { get; protected set; }

    protected virtual void Init()
    {

    }

    public abstract void Clear();
}