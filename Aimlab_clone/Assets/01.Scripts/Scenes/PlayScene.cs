public class PlayScene : BaseScene
{
    private void Awake()
    {
        Init();
    }

    private void OnEnable()
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
        GameManager.Instance.InitGame();
    }

    public override void Clear()
    {

    }
}
