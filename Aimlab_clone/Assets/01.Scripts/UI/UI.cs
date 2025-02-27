using System.Collections;
using UnityEngine;

public abstract class UI : MonoBehaviour
{
    protected virtual void Awake()
    {
        Init();
    }

    protected abstract void Init();

    public virtual void UIFunction()
    {
        return;
    }

    public virtual IEnumerator UIFunctionCoroutine()
    {
        yield return null;
    }
}
