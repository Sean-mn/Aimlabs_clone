public class PlayScene : BaseScene
{
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        GameManager.Instance.onGameOver -= Clear;
        GameManager.Instance.onGameOver += Clear;
    }

    private void OnDestroy()
    {
        GameManager.Instance.onGameOver -= Clear;
    }

    protected override void Init()
    {
        SceneType = Define.Scene.Play;

        UIManager.Instance.InitUI();
        GameManager.Instance.InitGame();
    }

    public override void Clear()
    {
        SceneController.Instance.LoadScene(Define.Scene.Rank);
    }
}