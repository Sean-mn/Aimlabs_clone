using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType { get; protected set; } = Define.Scene.UnKnown;

    protected virtual void Init()
    {

    }

    public abstract void Clear();
}