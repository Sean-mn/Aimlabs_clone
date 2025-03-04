public class PlayScene : BaseScene
{
    private void Awake()
    {
        Init();
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
