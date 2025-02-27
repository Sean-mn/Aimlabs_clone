using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    public void ActiveUI<T>(T ui) where T : Component
    {
        ui?.gameObject?.SetActive(true);
    }
}