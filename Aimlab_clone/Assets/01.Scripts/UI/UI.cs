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
    }
    public virtual void UIFunction(float value)
    {
    }
    public virtual IEnumerator UIFunctionCoroutine()
    {
        yield return null;
    }
    public virtual IEnumerator UIFunctionCoroutine(float value)
    {
        yield return null;
    }
}
