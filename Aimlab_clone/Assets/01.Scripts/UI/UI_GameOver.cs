using UnityEngine;

public class UI_GameOver : MonoBehaviour
{
    [field: SerializeField, Header("GameOver Panel")]
    public GameObject GameOverPanel { get; private set; }

    private void Awake()
    {
        GameOverPanel = GetComponent<GameObject>();
    }

    private void Start()
    {
        if (GameOverPanel != null && !GameManager.Instance.IsGameOver)
            GameOverPanel.SetActive(false);
    }
}
