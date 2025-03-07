using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType { get; protected set; }

    protected abstract void Init();

    public virtual void Clear()
    {

    }
}