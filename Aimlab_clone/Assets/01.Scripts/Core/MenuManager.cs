using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    GameLevel gameLevel;
    GameLevelManager gameLevelManager;

    [Header("Panels")]
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject helpPanel;

    [Header("Buttons")]
    [SerializeField] Button startBtn;
    [SerializeField] Button helpBtn;
    [SerializeField] Button rankBtn;

    private void Awake()
    {
        gameLevel = new();
        gameLevelManager = new GameLevelManager(gameLevel);
    }

    private void Start()
    {
        startPanel?.SetActive(false);

        startBtn.onClick.AddListener(ShowStartPanel);
        rankBtn.onClick.AddListener(GoRank);
    }

    public void ShowStartPanel()
    {
        startPanel.gameObject.SetActive(true);
    }

    public void ShowHelp()
    {
        helpPanel.SetActive(true);
    }

    public void GoRank()
    {
        SceneController.Instance.LoadScene(Define.Scene.Rank);
    }
}