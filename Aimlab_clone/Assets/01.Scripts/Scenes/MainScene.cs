public class MainScene : BaseScene
{
    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        SceneType = Define.Scene.Menu;
        GameManager.Instance.InitMain();
    }
}