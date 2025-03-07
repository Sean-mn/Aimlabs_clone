using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Define.Scene MainScene = Define.Scene.Menu;

    GameLevel gameLevel;
    GameLevelManager gameLevelManager;

    [Header("Panels")]
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject helpPanel;

    [Header("Buttons")]
    [SerializeField] Button startBtn;
    [SerializeField] Button helpBtn;
    [SerializeField] Button rankBtn;

    [SerializeField] private bool isHelpPanel = false;

    private void Awake()
    {
        gameLevel = new();
        gameLevelManager = new GameLevelManager(gameLevel);
    }

    private void Start()
    {
        startPanel?.SetActive(false);
        helpPanel?.SetActive(false);

        startBtn.onClick.AddListener(ShowStartPanel);
        helpBtn.onClick.AddListener(ShowHelp);
        rankBtn.onClick.AddListener(GoRank);
    }

    public void ShowStartPanel()
    {
        startPanel.gameObject.SetActive(true);
    }

    public void ShowHelp()
    {
        isHelpPanel = !isHelpPanel;
        helpPanel.SetActive(isHelpPanel);
    }

    public void GoRank()
    {
        SceneController.Instance.LoadScene(Define.Scene.Rank);
    }

    public void GetGameLovel(Define.GameLevel gameLevel, Action call)
    {
        gameLevelManager.SetLevel(gameLevel);
        call?.Invoke();
    }
}